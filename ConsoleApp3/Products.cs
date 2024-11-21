using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctionhouse;
using ClientInfo;

namespace Products
{
    public class Item : Advertise
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string price { get; set; }


        public Bid bid {get; set;}


    }
    public class Bid : Advertise
    {
        public int BidPrice { get; set; }
        public Item BidItem { get; set; }

        public Client Bidder { get; set; }


    }

}



