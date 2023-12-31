﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using WebHotel.DTO.PaymentDtos;

namespace WebHotel.Controllers.UserController;

[ApiController]
[ApiVersion("1.0")]
[Route("user/")]
public class MomoController : ControllerBase
{
    public MomoController() { }

    [HttpPost("payment/momoQR")]
    public IActionResult PostQR([FromBody] MomoRequestDto momoRequestDto)
    {
        string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
        string partnerCode = "MOMO5RGX20191128";
        string accessKey = "M8brj9K6E22vXoDB";
        string serectkey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
        string orderInfo = momoRequestDto.orderInfo!;
        string redirectUrl = "http://localhost:4200/successPayment";
        string ipnUrl = "http://localhost:4200/successPayment";
        string requestType = "captureWallet";

        string amount = momoRequestDto.amount!;
        string orderId = Guid.NewGuid().ToString();
        string requestId = Guid.NewGuid().ToString();
        string extraData = "";

        //Before sign HMAC SHA256 signature
        string rawHash = "accessKey=" + accessKey +
            "&amount=" + amount +
            "&extraData=" + extraData +
            "&ipnUrl=" + ipnUrl +
            "&orderId=" + orderId +
            "&orderInfo=" + orderInfo +
            "&partnerCode=" + partnerCode +
            "&redirectUrl=" + redirectUrl +
            "&requestId=" + requestId +
            "&requestType=" + requestType;

        // sign signature SHA256
        MoMoSecurity crypto = new MoMoSecurity();
        string signature = crypto.signSHA256(rawHash, serectkey);

        // build body json request
        JObject message = new JObject
        {
            { "partnerCode", partnerCode },
            { "partnerName", "Test" },
            { "storeId", "MomoTestStore" },
            { "requestId", requestId },
            { "amount", amount },
            { "orderId", orderId },
            { "orderInfo", orderInfo },
            { "redirectUrl", redirectUrl },
            { "ipnUrl", ipnUrl },
            { "lang", "en" },
            { "extraData", extraData },
            { "requestType", requestType },
            { "signature", signature }
        };

        string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());
        JObject jmessage = JObject.Parse(responseFromMomo);

        // return response
        return Ok(new
        {
            PayUrl = jmessage.GetValue("payUrl").ToString()
        });
    }
}

public class MoMoSecurity
{
    public string signSHA256(string message, string key)
    {
        byte[] keyByte = Encoding.UTF8.GetBytes(key);
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        using (var hmacsha256 = new HMACSHA256(keyByte))
        {
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            string hex = BitConverter.ToString(hashmessage);
            hex = hex.Replace("-", "").ToLower();
            return hex;
        }
    }
}

public class PaymentRequest
{
    public static string sendPaymentRequest(string endpoint, string postJsonString)
    {
        try
        {
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(endpoint);

            var postData = postJsonString;

            var data = Encoding.UTF8.GetBytes(postData);

            httpWReq.ProtocolVersion = HttpVersion.Version11;
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/json";
            httpWReq.ContentLength = data.Length;
            httpWReq.ReadWriteTimeout = 30000;
            httpWReq.Timeout = 15000;
            Stream stream = httpWReq.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

            string jsonresponse = "";

            using (var reader = new StreamReader(response.GetResponseStream()))
            {

                string temp = null!;
                while ((temp = reader.ReadLine()!) != null)
                {
                    jsonresponse += temp;
                }
            }


            //todo parse it
            return jsonresponse;
            //return new MomoResponse(mtid, jsonresponse);

        }
        catch (WebException e)
        {
            return e.Message;
        }
    }


}