namespace ProgiV2.Server
{
    public class CarPrices
    {
        public double Price { get; set; }

        public string Type { get; set; } = string.Empty;

        public double BaseFee { get
            {
                switch (this.Type)
                {
                    case "ord":
                        if (this.Price * 0.1 < 10) return 10;
                        if (this.Price * 0.1 > 50) return 50;
                        else return this.Price * 0.1;
                    case "luxe":
                        if (this.Price * 0.1 < 25) return 25;
                        if (this.Price * 0.1 > 200) return 200;
                        else return this.Price * 0.1;
                    default:
                        return 0.00;
                }
            } }

        public double SpecialFee { get {
                switch (this.Type)
                {
                    case "ord":
                        return this.Price * 0.02;
                    case "luxe":
                        return this.Price * 0.04;
                    default:
                        return 0.00;
                }
            } }
        public double AssociationFee { get {
                if (this.Price > 1.00 && this.Price <= 500.00) return 5.00;
                if (this.Price > 500.00 && this.Price <= 1000.00) return 10.00;
                if (this.Price > 1000 && this.Price <= 3000) return 15.00;
                if (this.Price > 3000) return 20.00;
                return 0.00;
            } }
        public double StorageFee { get { return 100.00; } }
    }
}
