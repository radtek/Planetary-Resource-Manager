﻿using PlanetaryResourceManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetaryResourceManager.Core.Helpers
{
    public class ProductionHelper
    {
        public const int BatchSize = 8000;

        public static ProductionResult Calculate(Product product, List<RawMaterial> materials, int batchSize = BatchSize)
        {
            if (materials.Count < 2)
            {
                throw new InvalidOperationException("At least two raw materials needed for every product");
            }

            ProductionResult result = new ProductionResult();
            result.InputQuantities = MapInputQuantities(materials, batchSize);
            result.OutputQuantity = product.OutputBatchSize * batchSize;
            result.InputQuantity = GetInputQuantities(result);
            result.SaleCost = product.Price * result.OutputQuantity;

            var productionExpense = (result.InputQuantities[materials[0].InputLevel] * materials[0].ImportCost) + 
                (result.InputQuantities[materials[1].InputLevel] * materials[1].ImportCost) + 
                (result.OutputQuantity * product.ExportCost);

            var purchaseCost = (materials[0].Price * result.InputQuantities[materials[0].InputLevel]) +
                (materials[1].Price * result.InputQuantities[materials[1].InputLevel]);

            if (materials.Count > 2)
            {
                productionExpense += (result.InputQuantities[materials[2].InputLevel] * materials[2].ImportCost);
                purchaseCost += (materials[2].Price * result.InputQuantities[materials[2].InputLevel]);
            }

            result.Expenses = productionExpense;
            result.PurchaseCost = purchaseCost;
            result.ProfitMargin = result.SaleCost - (result.PurchaseCost + result.Expenses);

            return result;
        }

        public static int GetInputBatchSize(int productionLevel)
        {
            switch (productionLevel)
            {
                case 1:
                    return 3000;
                case 2:
                    return 40;
                case 3:
                    return 10;
                case 4:
                    return 6;
                default:
                    return 0;
            }
        }

        public static int GetOutputBatchSize(int productionLevel)
        {
            switch (productionLevel)
            {
                case 2:
                    return 20;
                case 3:
                    return 5;
                case 4:
                    return 3;
                case 5:
                    return 1;
                default:
                    return 1;
            }
        }

        public static double GetImportCost(int productionLevel)
        {
            switch (productionLevel)
            {
                case 1:
                    return 0.25;
                case 2:
                    return 20;
                case 3:
                    return 360;
                case 4:
                    return 3000;
                default:
                    return 0;
            }
        }

        public static double GetImportCost(int productionLevel, double customsTaxRate)
        {
            switch (productionLevel)
            {
                case 2:
                    return CalculateCost(2.5, customsTaxRate);
                case 3:
                    return CalculateCost(200, customsTaxRate);
                case 4:
                    return CalculateCost(3800, customsTaxRate);
                case 5:
                    return CalculateCost(30000, customsTaxRate);
                default:
                    return 0;
            }
        }

        public static double GetExportCost(int productionLevel)
        {
            switch (productionLevel)
            {
                case 2:
                    return 40;
                case 3:
                    return 720;
                case 4:
                    return 6000;
                case 5:
                    return 120000;
                default:
                    return 0.40;
            }
        }

        public static double GetExportCost(int productionLevel, double customsTaxRate)
        {
            switch (productionLevel)
            {
                case 1:
                    return CalculateCost(5, customsTaxRate);
                case 2:
                    return CalculateCost(400, customsTaxRate);
                case 3:
                    return CalculateCost(7200, customsTaxRate);
                case 4:
                    return CalculateCost(60000, customsTaxRate);
                case 5:
                    return CalculateCost(120000, customsTaxRate);
                default:
                    return 0;
            }
        }

        private static double CalculateCost(double coefficient, double taxRate)
        {
            return (coefficient / 100) * taxRate;
        }

        private static Dictionary<int, int> MapInputQuantities(IEnumerable<RawMaterial> materials, int batchSize)
        {
            var distinctInputs = materials.Distinct(new InputComparer());
            var inputDictionary = distinctInputs.ToDictionary(key => key.InputLevel, value => value.InputBatchSize * batchSize);
            return inputDictionary;
        }

        private static string GetInputQuantities(ProductionResult result)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;

            foreach(var key in result.InputQuantities.Keys)
            {
                if (index == 0)
                {
                    builder.AppendFormat("{0}", result.InputQuantities[key]);
                }
                else
                {
                    builder.AppendFormat(" /{0}", result.InputQuantities[key]);
                }

                index++;
            }

            return builder.ToString();
        }
    }
}
