//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace soso
//{
//    class ContainUrl
//    {
//        public static int URLNumber = 20000;//url容器容量
//        DocInfo[] url = new DocInfo[URLNumber];
//        public int index = 0;
//        public void EnQueue(DocInfo mu)
//        {
//            lock (this)
//            {
//                while (index == URLNumber)
//                {
//                    Monitor.Wait(this);//容器已满等待消费url
//                }
//                url[index] = mu;
//                index++;
//                Monitor.PulseAll(this);
//            }
//        }
//        public DocInfo DeQueue()
//        {
//            lock (this)
//            {
//                while (index == 0)
//                {
//                    Monitor.Wait(this);//url用完等待生产
//                }
//                index--;
//                Monitor.PulseAll(this);
//                return url[index];
//            }
//        }
//    }
//}
