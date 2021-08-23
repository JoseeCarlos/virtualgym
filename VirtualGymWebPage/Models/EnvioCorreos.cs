using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;

namespace VirtualGymWebPage.Models
{
    public class EnvioCorreos
    {
        public void EnviarCorreo(String destino, string usuario, string password)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("virtualgymwebpage@gmail.com");//correo del que se enviara
                correo.To.Add(destino);
                correo.Subject = "Confirmacion de correo"; //Asunto
                correo.Body = "Gracias por registrarse en VirtualGym \n su nombre de usuario es: " + usuario + " , su password es: " + password; //Mensaje
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string sCuentaCorreo = "virtualgymwebpage@gmail.com";
                string sPasswordCorreo = "79751575";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarCorreoCodigo(String destino, string codigo)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("virtualgymwebpage@gmail.com");//correo del que se enviara
                correo.To.Add(destino);
                correo.Subject = "Codigo de confirmacion"; //Asunto
                correo.Body = "su codigo es : " + codigo; //Mensaje
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string sCuentaCorreo = "virtualgymwebpage@gmail.com";
                string sPasswordCorreo = "79751575";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void EnviarCorreoPrivado(string remitente, string password, string asunto, string mensaje)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(remitente); //correo del que se enviara
                correo.To.Add("virtualgymwebpage@gmail.com");
                correo.Subject = asunto; //Asunto
                correo.Body = mensaje; //Mensaje
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string sCuentaCorreo = remitente;
                string sPasswordCorreo = password;
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}