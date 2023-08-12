namespace Gorsel8HaftaOptikOkuyucu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string dosya_yolu; // global dosya yolu(@C:\...)
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // textboxtaki dosya yolunu atama
            dosya_yolu = textBox3.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // bir sonraki hesaplama i�in otomatik listboxu temizler.
            listBox1.Items.Clear();

            StreamReader sw = new StreamReader(dosya_yolu);

            string yazi = sw.ReadLine();// ilk sat�r
            string aSatiri = yazi; // A kitap����n� tan�mlad�k.
            yazi = sw.ReadLine(); // ikinci sat�r
            string bSatiri = yazi;// B kitap�i�ini tan�mlad�k.
            
            string cozum;
            // if else 1 adet kullanmak i�in kodumuzu k�saltt�k ve 
            //her sat�r i�in farkl� kitap�ik t�r�n� belirlemek i�in 
            //cozum stringine do�ru kitap����n�z� atad�k.(while i�inde)


            while (yazi != null)
            {
                yazi = sw.ReadLine(); //3. sat�rdan son sat�ra kadar tek tek okur.
                if (yazi == null)// son sat�rdan sonra null sat�r� gelir.
                    break;// d�ng�den bu �ekilde ��k�l�r.


                int dogruSayac = 0;
                int yanlisSayac = 0;
                int bosSayac = 0;
                
                // n. ci sat�r�m�z�n kitap��k t�r�n� belirleme
                //*************************
                if (yazi[0] == aSatiri[0])
                    cozum = aSatiri;
                else
                    cozum = bSatiri;
                //*************************

                //*** kitap��k t�r�ne g�re kar��la�t�rma ***********
                for (int i = 13; i< Convert.ToInt32(textBox1.Text)+13; i++)
                {    
                    if(yazi[i]!=cozum[i])
                    {
                        if (yazi[i] == ' ')
                        {
                            bosSayac++;
                        }
                        else
                        {
                            yanlisSayac++;
                        }
                    }
                    if(yazi[i]==cozum[i])
                    {
                        dogruSayac++;
                    }
                }//****for d�ng�s� sonu ****************************

                //************list box'a ekleme *******************
                string yazilacak ="";
                for (int i = 1; i < 13; i++)
                    yazilacak += yazi[i].ToString();
                //ToString("D2") = integer say�s�n� 2 basamakl� yaz demek. �rnek: 1 say�s� = 01 yazar.
                yazilacak += "  D:"+dogruSayac.ToString("D2")+"  Y:"+yanlisSayac.ToString("D2")+"  B:"+bosSayac.ToString("D2");
                


                double puan =dogruSayac*Convert.ToDouble(textBox2.Text);// dogru sayisi �arp� paun
                yazilacak += "    Puan:"+ puan.ToString("#00"); // ("#00.00 ya da #0.## olabilir.)
                listBox1.Items.Add(yazilacak);
                // list box'a ekleme sonu ***********************
                //not: Console.WriteLine("{0:0.00}", veri); yap�l�rsa format� belirlemi� oluruz.
            }// while sonu
        }//button2  "hesapla" sonu

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}