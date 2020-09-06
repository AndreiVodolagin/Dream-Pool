using DreamsPool.Controllers;
using DreamsPool.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DreamsPool.Services
{
    public class MailAlert
    {
        
        Admin admin;

        public MailAlert(IAdminRepository rep)
        {
            admin = rep.Admins.FirstOrDefault();
        }


        /*public void SendMessage(Customer customer)
        {
            SmtpClient client = new SmtpClient("smtp.mail.ru");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(admin.Email, admin.Pass);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(admin.Email);
            mailMessage.To.Add(admin.Email);
            mailMessage.Body = customer.Name + "\n" + customer.Email + "\n" + customer.Phone + "\n" + customer.Language;
            mailMessage.Subject = "new order";
            client.EnableSsl = true;
            client.Send(mailMessage);
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void SendMessage(Customer customer)
        {
            var message = new
            {
                text = $"{customer.Name}\n {customer.Phone}\n{customer.Language}\n {customer.Email}"
            };

            var json = JsonConvert.SerializeObject(message);
            var webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.UploadString(admin.SlacKey, json);
        }
    }
}
