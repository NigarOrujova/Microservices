namespace CodeAcademy.Catalog.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
