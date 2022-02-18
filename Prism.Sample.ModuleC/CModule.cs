using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Sample.ModuleC.View;

namespace FileBrowser
{
        public static class GlobalRegion
        {
        public static IRegion handle;
         }

   

        public class CModule : IModule
        {
        //private readonly IRegionViewRegistry _regionViewRegistry = null;
        private readonly IRegionManager m_RegionManager;

        //public CModule(IRegionViewRegistry regionViewRegistry)
        //{
        //    _regionViewRegistry = regionViewRegistry;
        //}

        public CModule(IRegionManager regionManager)
        {
            m_RegionManager = regionManager;
        }

        public void Initialize()
        {
            var mainRegion = m_RegionManager.Regions["MainRegion"];
            var view = new FolderBrowserDialog();
            mainRegion.Add(view, "Folder");
            var view2 = new CView();
            mainRegion.Add(view2, "ModuleC");
            //mainRegion.Activate(view2);
            GlobalRegion.handle = mainRegion;

            

            //_regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(FolderBrowserDialog));

            //_regionViewRegistry.RegisterViewWithRegion("MainRegion2", typeof(CView));

        }
    
    }
}
