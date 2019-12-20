namespace GenericModel.Other
{
    public class HashHelper
    {
        private int Hash { get; set; }
        
        public HashHelper()
        {
            unchecked
            {
                this.Hash = (int)2166136261;
            }
        }

        public int Get()
        {
            return this.Hash;
        }
        public void Add(object obj)
        {
            unchecked
            {
                int objHashCode = (obj == null)?0: objHashCode = obj.GetHashCode();

                this.Hash = this.Hash * 16777619 + objHashCode;
            }
        }
    }
}
