package md5db63fd2b12f510b51cc781fba11baf01;


public class EventRecyclerViewAdapter
	extends md5db63fd2b12f510b51cc781fba11baf01.SimpleEventRecyclerViewAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateViewHolder:(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;:GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler\n" +
			"";
		mono.android.Runtime.register ("SportLead_1.Helpers.EventRecyclerViewAdapter, SportLead_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EventRecyclerViewAdapter.class, __md_methods);
	}


	public EventRecyclerViewAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EventRecyclerViewAdapter.class)
			mono.android.TypeManager.Activate ("SportLead_1.Helpers.EventRecyclerViewAdapter, SportLead_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public android.support.v7.widget.RecyclerView.ViewHolder onCreateViewHolder (android.view.ViewGroup p0, int p1)
	{
		return n_onCreateViewHolder (p0, p1);
	}

	private native android.support.v7.widget.RecyclerView.ViewHolder n_onCreateViewHolder (android.view.ViewGroup p0, int p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
