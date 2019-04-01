using LBFVideoLib.Common;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LBFVideoLib.Client
{
    public static class CommonAppStateDataHelper
    {
        static CommonAppStateDataHelper()
        {
            _applicationFormList = new List<Form>();
        }
        private static List<Form> _applicationFormList;

        public static void AddForm(Form currentForm)
        {
            _applicationFormList.Add(currentForm);
        }

        public static Form FindFormByFormType(string formName)
        {
            return _applicationFormList.FirstOrDefault(k => k.Name.ToLower().Equals(formName.ToLower()));
        }

        public static ClientInfo ClientInfoObject { get; set; }

        public static bool LicenseError { get; set; } = false;
        public static bool LoggedIn { get; set; } = false;

    }
}
