namespace WpfApplication1
{
    internal class comboBoxItem
    {
        public decimal id { get; set; }
        public string descripcion { get; set; }


        public comboBoxItem()
        {

        }

        public override string ToString()
        {
            return descripcion;
        }
    }
}