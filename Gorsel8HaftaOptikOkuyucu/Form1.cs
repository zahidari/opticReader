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
            // bir sonraki hesaplama için otomatik listboxu temizler.
            listBox1.Items.Clear();

            StreamReader sw = new StreamReader(dosya_yolu);

            string yazi = sw.ReadLine();// ilk satýr
            string aSatiri = yazi; // A kitapçýðýný tanýmladýk.
            yazi = sw.ReadLine(); // ikinci satýr
            string bSatiri = yazi;// B kitapçiðini tanýmladýk.
            
            string cozum;
            // if else 1 adet kullanmak için kodumuzu kýsalttýk ve 
            //her satýr için farklý kitapçik türünü belirlemek için 
            //cozum stringine doðru kitapçýðýnýzý atadýk.(while içinde)


            while (yazi != null)
            {
                yazi = sw.ReadLine(); //3. satýrdan son satýra kadar tek tek okur.
                if (yazi == null)// son satýrdan sonra null satýrý gelir.
                    break;// döngüden bu þekilde çýkýlýr.


                int dogruSayac = 0;
                int yanlisSayac = 0;
                int bosSayac = 0;
                
                // n. ci satýrýmýzýn kitapçýk türünü belirleme
                //*************************
                if (yazi[0] == aSatiri[0])
                    cozum = aSatiri;
                else
                    cozum = bSatiri;
                //*************************

                //*** kitapçýk türüne göre karþýlaþtýrma ***********
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
                }//****for döngüsü sonu ****************************

                //************list box'a ekleme *******************
                string yazilacak ="";
                for (int i = 1; i < 13; i++)
                    yazilacak += yazi[i].ToString();
                //ToString("D2") = integer sayýsýný 2 basamaklý yaz demek. örnek: 1 sayýsý = 01 yazar.
                yazilacak += "  D:"+dogruSayac.ToString("D2")+"  Y:"+yanlisSayac.ToString("D2")+"  B:"+bosSayac.ToString("D2");
                


                double puan =dogruSayac*Convert.ToDouble(textBox2.Text);// dogru sayisi çarpý paun
                yazilacak += "    Puan:"+ puan.ToString("#00"); // ("#00.00 ya da #0.## olabilir.)
                listBox1.Items.Add(yazilacak);
                // list box'a ekleme sonu ***********************
                //not: Console.WriteLine("{0:0.00}", veri); yapýlýrsa formatý belirlemiþ oluruz.
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