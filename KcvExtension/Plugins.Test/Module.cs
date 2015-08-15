using AMing.KcvExtension.Core.Generic;
using AMing.KcvExtension.Core.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Test
{
    public class Module : ModulesBase
    {
        public static Module Current { get; } = new Module();

        public override string Key { get; set; } = "TestPlugins";

        public override void Initialize_Start()
        {
            MethodHub.Current.Register("test.key", TestMethod);
        }


        private dynamic TestMethod(dynamic val)
        {
            var r_val = new DynamicArgs<int, string, string>()
            {
                val2 = "tsestatatt"
            };
            if (DynamicArgs<int>.Validation(val))
            {
                r_val.val2 += "\nint";
            }
            if (DynamicArgsBase.Validation(val, "DynamicArgs.Int32.String"))
            {
                r_val.val1 = val.val1;
                r_val.val3 = val.val2;
                r_val.val2 += "\nintString";
            }

            //dynamic args = new System.Dynamic.ExpandoObject();
            ////args.test = 123;
            ////args.v = val.aaa;
            //args.stauts = val.bbb;
            //args.data = new TestModel
            //{
            //    ID = 2443,
            //    Name = "test name.",
            //    Enable = true
            //};

            ////return args;

            //return new TestModel
            //{
            //    ID = 2443,
            //    Name = "test name.",
            //    Enable = true
            //};

            return r_val;
        }
    }
}
