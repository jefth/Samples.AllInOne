﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orleans.Grains
{
    public class Promotion
    {
        public Guid Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public Promotion(DateTime startTime, DateTime endTime)
        {
            Id = Guid.NewGuid();
            StartTime = startTime;
            EndTime = endTime;
            PromotionProducts = new List<PromotionProduct>();
        }


        public List<PromotionProduct> PromotionProducts { get; private set; }

        public void AddPromotionProduct(PromotionProduct product)
        {
            product.PromotionId = this.Id;
            this.PromotionProducts.Add(product);
        }

        public override string ToString()
        {
            string list = string.Join(Environment.NewLine, PromotionProducts.Select(product => product.ToString()));
            return $"Promotion Id:{Id},StartTim:{StartTime},EndTime:{EndTime}" + Environment.NewLine
                                                                               + $"Promotion Products" + Environment.NewLine + $"{list}";
        }
    }
}

