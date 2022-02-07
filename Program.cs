using System;
using System.Text;
using System.Security.Cryptography;


namespace Merkly
{
    class Program
    { 

        static void Main(string[] args)
        {

            string tx1Hash = "aad28e85f31ae79339b49d114d7c1811d2c667681a1904ebbc326842a0a81985";
            string tx2Hash = "b963d3426088217357b146d5600817c54f93c2ea1a23126988e36460015ffc0e";
            string tx3Hash = "82498f4da1e1b662b02e95150dc9fd64307ee96b35657f75c7abd82530168ce3";
            string tx4Hash = "ceecfd37686a3ed1759d3cef25e412a800fc8e8846154dbe2a2d72b2af3e3b64";

            //2
            Yaaasss mkly12 = new Yaaasss(tx1Hash,tx2Hash);
            Console.WriteLine(mkly12.Hash);
            string tx12Hash = mkly12.HashCalculate(mkly12.Hash);
            Console.WriteLine(tx12Hash);

            //3
            Yaaasss mkly34 = new Yaaasss(tx3Hash, tx4Hash);
            Console.WriteLine(mkly34.Hash);
            string tx34Hash = mkly34.HashCalculate(mkly34.Hash);
            Console.WriteLine(tx34Hash);

            //4
            Yaaasss mkly1234 = new Yaaasss(tx12Hash, tx34Hash);
            Console.WriteLine(mkly34.Hash);
            string tx1234Hash = mkly1234.HashCalculate(mkly1234.Hash);

            Console.WriteLine(tx1234Hash);
        }
     class Yaaasss
        {
            public string Hash { get; set; }

            public Yaaasss(string hash1, string hash2)
            {
                string tohash = hash1 + hash2;
                this.Hash = HashCalculate(tohash);
            }
            public string HashCalculate(string input)
            {

                string stringTohash = input;
                byte[] bytes = Encoding.UTF8.GetBytes(stringTohash);
                byte[] hashBytes = SHA256.Create().ComputeHash(bytes);
                string hexHash = BitConverter.ToString(hashBytes).Replace("-", "");
                return hexHash;

            }
        } 
    }
}
