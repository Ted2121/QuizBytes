using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApiClient;

namespace ByteManager.Client_Singletons
{
    public sealed class SubjectFacadeSingleton
    {
        SubjectFacadeSingleton() { }
        private static readonly object lockObj = new object();
        private static SubjectFacadeApiClient instance = null;
        public static SubjectFacadeApiClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new SubjectFacadeApiClient(Configuration.WebApiUri);
                        }
                    }
                }
                return instance;
            }
        }
    }
}
