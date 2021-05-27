using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_Android.Activities;
using DrunkenWizard_Android.Adapters;
using DrunkenWizard_Android.Interfaces;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Fragments
{
    class DragonsFragment: Fragment, IBackButtonListener
    {
        RecyclerView rcvDragons;
        DragonsFragmentAdapter adapter;
        BossFightViewModel _bfVM = ServiceContainer.Resolve<BossFightViewModel>();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public static DragonsFragment NewInstance()
        {
            var fragdrag = new DragonsFragment { Arguments = new Bundle() };
            return fragdrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.DragonsFragment, null);
            rcvDragons = view.FindViewById<RecyclerView>(Resource.Id.rcvDragons);
            LinearLayoutManager llm = new LinearLayoutManager(Context);
            rcvDragons.SetLayoutManager(llm);
            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rcvDragons.Context, DividerItemDecoration.Vertical);
            rcvDragons.AddItemDecoration(dividerItemDecoration);
            adapter = new DragonsFragmentAdapter(Context);
            adapter.CellClicked += CellCLicked;
            rcvDragons.SetAdapter(adapter);
            var toolbartitel = Activity.FindViewById<TextView>(Resource.Id.toolbartitle);
            toolbartitel.Text = "Dragons";

            return view;

        }
        private void CellCLicked(object sender, Monster e)
        {
            _bfVM.SelectedDragon = e;
            var intent = new Intent(Context, typeof(DragonsDetailActivity))
                .SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(intent);

        }
        public void OnBackPressed()
        {
            Activity.SupportFragmentManager.PopBackStack();
        }
    }
}