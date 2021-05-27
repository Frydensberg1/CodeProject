using SupportFragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using DrunkenWizard_Android.Adapters;

namespace DrunkenWizard_Android.Fragments
{
    class SymbolsFragment : SupportFragment
    {
        RecyclerView recyclerViewSymbol;
        RecyclerSymbolAdapter adapter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.SymbolsLayout, container, false);
            recyclerViewSymbol = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewSymbol);
            LinearLayoutManager llm = new LinearLayoutManager(Context);
            recyclerViewSymbol.SetLayoutManager(llm);
            adapter = new RecyclerSymbolAdapter(Context);
            recyclerViewSymbol.SetAdapter(adapter);

            return view;
        }
    }
}