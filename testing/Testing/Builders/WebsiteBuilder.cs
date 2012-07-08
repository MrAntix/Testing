using Testing.Base;
using Testing.Models;

namespace Testing.Builders
{
    public class WebsiteBuilder : BuilderBase<WebsiteBuilder, TestingWebsiteModel>
    {
        readonly IDataContainer _dataContainer;

        public WebsiteBuilder(IDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            Assign = x =>
                         {
                             var subDomain = "";
                             switch ((int) _dataContainer.Double.With(0, 10).BuildItem())
                             {
                                 case 1:
                                 case 2:
                                 case 3:
                                 case 4:
                                 case 5:
                                     subDomain = "www.";
                                     break;
                                 case 6:
                                     subDomain =
                                         _dataContainer.Text.With(1, 10, _dataContainer.Resources.Letters).BuildItem() +
                                         ".";
                                     break;
                             }

                             x.Address = string.Format(
                                 "http://{0}{1}/",
                                 subDomain,
                                 _dataContainer.Resources.WebDomains.OneOf()
                                 );
                         };
        }

        protected override WebsiteBuilder CreateClone()
        {
            return new WebsiteBuilder(_dataContainer);
        }
    }
}