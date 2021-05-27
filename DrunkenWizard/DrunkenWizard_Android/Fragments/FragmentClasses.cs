using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_Android.Adapters;
using DrunkenWizard_Android.Interfaces;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Fragments
{
    public class FragmentClasses: Fragment, IBackButtonListener
    {
        RecyclerView rcvClass;
        FragmentClassAdapter adapter;
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentClasses NewInstance()
        {
            var fragclass = new FragmentClasses { Arguments = new Bundle() };
            return fragclass;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.FragmentClasses, null);
            rcvClass = view.FindViewById<RecyclerView>(Resource.Id.rcvClass);
            LinearLayoutManager llm = new LinearLayoutManager(Context);
            rcvClass.SetLayoutManager(llm);
            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rcvClass.Context, DividerItemDecoration.Vertical);
            rcvClass.AddItemDecoration(dividerItemDecoration);
            adapter = new FragmentClassAdapter(Context);
            adapter.SpellsClicked += SpellsClicked;
            rcvClass.SetAdapter(adapter);
            var toolbartitel = Activity.FindViewById<TextView>(Resource.Id.toolbartitle);
            toolbartitel.Text = "Classes";
            return view;
   
        }

     

        private void SpellsClicked(object sender, GameClass e)
        {
            _cVM.SelectedClass = e;
            var intent = new Intent(Context.ApplicationContext, typeof(ClassDetailActivity))
                       .SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(intent);
        }
 
        public void OnBackPressed()
        {
            Activity.SupportFragmentManager.PopBackStack();
        }
    }
}