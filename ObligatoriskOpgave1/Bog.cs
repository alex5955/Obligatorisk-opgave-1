using System;

namespace ObligatoriskOpgave1
{
    public class Bog
    {
        private string _titel;
        private string _forfatter;
        private int _sidetal;
        private string _isbn13;

        public string Titel
        {
            get => _titel;
            set
            {
                CheckTitel(value);
                _titel = value;
            }
        }

        public string Forfatter
        {
            get => _forfatter;
            set => _forfatter = value;
        }

        public int Sidetal
        {
            get => _sidetal;
            set
            {
                CheckSidetal(value);
                _sidetal = value;
            } 
        }

        public string Isbn13
        {
            get => _isbn13;
            set
            {
                Check13(value);
                _isbn13 = value;
            } 
        }

        public Bog(string titel, string forfatter, int sidetal, string isbn13)
        {
            CheckTitel(titel);
            _titel = titel;

            _forfatter = forfatter;

            CheckSidetal(sidetal);
            _sidetal = sidetal;

            Check13(isbn13);
            _isbn13 = isbn13;
        }

        private void CheckTitel(string titel)
        {
            if(titel.Length < 2) throw new ArgumentException("Titel skal være længere end 2 tegn");
        }

        private void CheckSidetal(int sidetal)
        {
            if (sidetal < 10 || sidetal > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(sidetal), sidetal, "Sidetal skal være mellem 10 og 1000");
            }
        }

        private void Check13(string isbn13)
        {
            if (isbn13.Length != 13)
            {
                throw new ArgumentException("isbn13 skal være 13 tegn langt");
            }
        }
    }
}
