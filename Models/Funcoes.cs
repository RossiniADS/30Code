using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Drawing;
using System.IO;
using System.Web.Mvc;

namespace _30Code.Models
{
    public class Funcoes
    {
        public static string EnviarEmail(string emailDestinatario, string assunto, string corpomsg)
        {
            try
            {
                //Cria o endereço de email do remetente
                MailAddress de = new MailAddress("Fatec ADS <fatecgtaads@gmail.com>");
                //Cria o endereço de email do destinatário -->
                MailAddress para = new MailAddress(emailDestinatario);
                MailMessage mensagem = new MailMessage(de, para);
                mensagem.IsBodyHtml = true;
                //Assunto do email
                mensagem.Subject = assunto;
                //Conteúdo do email
                mensagem.Body = corpomsg;
                //Prioridade E-mail
                mensagem.Priority = MailPriority.Normal;
                //Cria o objeto que envia o e-mail
                SmtpClient cliente = new SmtpClient();
                //Envia o email
                cliente.Send(mensagem);
                return "success|E-mail enviado com sucesso";
            }
            catch { return "error|Erro ao enviar e-mail"; }
        }

        public static string Codifica(string texto)
        {
            byte[] stringBase64 = new byte[texto.Length];
            stringBase64 = Encoding.UTF8.GetBytes(texto);
            string codifica = Convert.ToBase64String(stringBase64);
            return codifica;
        }
        public static string Decodifica(string texto)
        {
            var encode = new UTF8Encoding();
            var utf8Decode = encode.GetDecoder();

            byte[] stringValor = Convert.FromBase64String(texto);
            int contador = utf8Decode.GetCharCount(stringValor, 0,
            stringValor.Length);
            char[] decodeChar = new char[contador];
            utf8Decode.GetChars(stringValor, 0, stringValor.Length, decodeChar, 0);
            string resultado = new String(decodeChar);
            return resultado;
        }
        public static string HashTexto(string texto, string nomeHash)
        {
            HashAlgorithm algoritmo = HashAlgorithm.Create(nomeHash);
            if (algoritmo == null)
            {
                throw new ArgumentException("Nome de hash incorreto", "nomeHash");
            }
            byte[] hash = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(texto));
            return Convert.ToBase64String(hash);
        }
        public static string RedefinirImagemSalvar(string imagePath, int largura, int altura, string prefixo)
        {
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imagePath);

            var thumbnailImg = new Bitmap(largura, altura);
            var thumbGraph = Graphics.FromImage(thumbnailImg);

            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            var imageRectangle = new Rectangle(0, 0, largura, altura);
            thumbGraph.DrawImage(fullSizeImg, imageRectangle);
            string targetPath = imagePath.Replace(Path.GetFileNameWithoutExtension(imagePath), prefixo + Path.GetFileNameWithoutExtension(imagePath));
            thumbnailImg.Save(targetPath);

            thumbnailImg.Dispose();
            fullSizeImg.Dispose();

            return targetPath;
        }
        public static bool CriarDiretorio(string pasta)
        {
            string dir = HttpContext.Current.Request.PhysicalApplicationPath + "assets\\img\\" + pasta + "\\";

            if (!Directory.Exists(dir))
            {
                //Caso não exista devermos criar
                Directory.CreateDirectory(dir);
                return true;
            }
            else
                return false;
        }
        public static bool ExcluirArquivo(string arq)
        {
            if (File.Exists(arq))
            {
                File.Delete(arq);
                return true;
            }
            else
                return false;
        }
        public static string UploadArquivo(HttpPostedFileBase flpUpload, string pasta, string nome)
        {
            try
            {
                double permitido = 900;
                if (flpUpload != null)
                {
                    string arq = Path.GetFileName(flpUpload.FileName);
                    double tamanho = Convert.ToDouble(flpUpload.ContentLength) / 1024;
                    string extensao = Path.GetExtension(flpUpload.FileName).ToLower();
                    string diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "assets\\img\\" + pasta + "\\" + nome;


                    if (tamanho > permitido)
                        return "Tamanho Máximo permitido é de " + permitido + " kb!";
                    else if ((extensao != ".png" && extensao != ".jpg"))
                        return "Extensão inválida, só são permitidas .png e .jpg!";
                    else
                    {
                        if (!File.Exists(diretorio))
                        {
                            flpUpload.SaveAs(diretorio);
                            RedefinirImagemSalvar(diretorio, 48, 48, "mini_");
                            return "sucesso";
                        }
                        else
                            return "Já existe um arquivo com esse nome!";
                    }
                }
                else
                    return "Erro no Upload!";
            }
            catch { return "Erro no Upload"; }

        }
    }

}