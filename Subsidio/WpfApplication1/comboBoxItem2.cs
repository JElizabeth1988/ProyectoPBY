namespace WpfApplication1
{
    internal class comboBoxItem2
    {
        public decimal id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }


        public comboBoxItem2()
        {

        }

        public override string ToString()
        {
            return nombre;
        }
    }
}