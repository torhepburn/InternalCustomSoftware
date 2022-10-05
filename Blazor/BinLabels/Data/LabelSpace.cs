
namespace LabelSpace.Data
{
    
    public class Label
    {
        private string num;
        private string name;
        private string rev;

        public Label(string num, string name, string rev)
        {
            this.num = num;
            this.name = name;
            this.rev = rev;
        }

        public string Num
        {
            get { return num; }
            set { num = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Rev
        {
            get { return rev; }
            set { rev = value; }
        }
    }


}