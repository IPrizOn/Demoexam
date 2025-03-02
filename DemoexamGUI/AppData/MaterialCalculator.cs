using DemoexamGUI.Domain;

namespace DemoexamGUI.AppData
{
    public class MaterialCalculator
    {
        private ProductType[] productTypes;
        private MaterialType[] materialTypes;

        public MaterialCalculator(ProductType[] productTypes, MaterialType[] materialTypes)
        {
            this.productTypes = productTypes;
            this.materialTypes = materialTypes;
        }

        public int CalculateMaterialQuantity(int productId, int materialId, int productCount, double param1, double param2)
        {
            var productType = productTypes.FirstOrDefault(pt => pt.Id == productId);
            var materialType = materialTypes.FirstOrDefault(mt => mt.Id == materialId);

            if (productType == null || materialType == null)
            {
                return -1; 
            }

            if (productCount <= 0 || param1 <= 0 || param2 <= 0)
            {
                return -1; 
            }

            double materialPerUnit = param1 * param2 * productType.TypeCoefficient;

            double defectFactor = 1 + materialType.DefectRate;

            double totalMaterial = materialPerUnit * productCount * defectFactor;

            return (int)Math.Ceiling(totalMaterial);
        }
    }
}
