namespace opfa_common_managed
{
    public abstract class Layout
    {
        //internal members
        internal volatile byte baseCost;
        //properties
        public byte BaseCost { get { return baseCost; } }
        //constructor
        protected Layout( byte baseCost = 10)
        {
            this.baseCost = baseCost;
        }
        //abstract methods
        public abstract void GenerateEmptyLayout();
        public abstract void GenerateBlockRandomLayout(byte blockFrequency);
        public abstract void GenerateRandomLayout(byte blockFrequency, byte resistanceCap);
    }
}
