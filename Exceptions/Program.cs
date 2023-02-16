using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region try catch 1.örnek
            //try
            //{
            //    Find();
            //}
            //catch (RecordNotFoundException exception)
            //{
            //    Console.WriteLine(exception.Message);
            //}

            #endregion

            #region Action Delegasyonu

            HandleException(() => // parametre olarak method gönderiyoruz.
            {
                Find(); //action
            });



            #endregion


            Console.ReadLine();
        }

        private static void HandleException(Action action)
        {
            // Merkezi try catch bloğudur.
            try
            {
               action.Invoke(); //find kısmı çalışır.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static void Find()
        {
            List<string> sehirler = new List<string>() { "İSTANBUL", "AYDIN", "KAYSERİ" };
            if (!sehirler.Contains("ADIYAMAN"))
            {
                throw new RecordNotFoundException("Kayıt Bulunamadı.!"); //hata oluştur.
            }
            else
            {
                Console.WriteLine("Kayıt bulundu");
            }
        } //1.örnek method
    }
    
    public class RecordNotFoundException:Exception 
    {
        public RecordNotFoundException(string message):base(message)
        {
        }
    } //1.örnek
}
