using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApiClient;

namespace ByteManager.Client_Singletons
{
    public sealed class ChapterFacadeSingleton
    {
        ChapterFacadeSingleton() { }
        private static readonly object lockObj = new object ();  
    private static ChapterFacadeApiClient instance = null;
        public static ChapterFacadeApiClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                        {
                            if (instance == null)
                            {
                                instance = new ChapterFacadeApiClient(Configuration.WebApiUri);
                            }
                        }
                }
                return instance;
            }
        }
    }
}
