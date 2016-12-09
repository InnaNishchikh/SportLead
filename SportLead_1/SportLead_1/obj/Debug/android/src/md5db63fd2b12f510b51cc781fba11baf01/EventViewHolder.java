package md5db63fd2b12f510b51cc781fba11baf01;


public class EventViewHolder
	extends md5db63fd2b12f510b51cc781fba11baf01.SimpleViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SportLead_1.Helpers.EventViewHolder, SportLead_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EventViewHolder.class, __md_methods);
	}


	public EventViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == EventViewHolder.class)
			mono.android.TypeManager.Activate ("SportLead_1.Helpers.EventViewHolder, SportLead_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
