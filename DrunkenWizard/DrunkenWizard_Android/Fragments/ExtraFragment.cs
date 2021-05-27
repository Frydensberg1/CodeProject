using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Support.V7.Widget;
using DrunkenWizard_Android.Adapters;

namespace DrunkenWizard_Android.Fragments
{
    class ExtraFragment : Fragment
    {
        RecyclerView rcv;
        ExtraFragmentAdapter mAdapter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.ExtraFragmentLayout, null);
            mAdapter = new ExtraFragmentAdapter(Context);
            rcv = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewExtra);
            LinearLayoutManager llm = new LinearLayoutManager(Context);
            rcv.SetLayoutManager(llm);
            rcv.SetAdapter(mAdapter);
            return view;
        }
    }
}