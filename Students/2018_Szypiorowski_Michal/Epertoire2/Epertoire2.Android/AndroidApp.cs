using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System;

namespace Epertoire2.Droid
{
    [Application]
    public partial class AndroidApp : Application, Application.IActivityLifecycleCallbacks
    {
        internal static Context CurrentContext;

        public AndroidApp(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            UnregisterActivityLifecycleCallbacks(this);
            base.OnTerminate();
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentContext = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {

        }

        public void OnActivityPaused(Activity activity)
        {

        }

        public void OnActivityResumed(Activity activity)
        {
            CurrentContext = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {

        }

        public void OnActivityStarted(Activity activity)
        {
            CurrentContext = activity;
        }

        public void OnActivityStopped(Activity activity)
        {

        }
    }
}