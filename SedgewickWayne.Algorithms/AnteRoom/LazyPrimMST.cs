public class LazyPrimMST
{
	private double weight;
//[Signature("LQueue<LEdge;>;")]
	private Queue mst;
	private bool[] marked;
//[Signature("LMinPQ<LEdge;>;")]
	private MinPQ pq;
//[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
	internal static bool s_assertionsDisabled;
	
	
	
	
	private void prim(EdgeWeightedGraph edgeWeightedGraph, int num)
	{
		this.scan(edgeWeightedGraph, num);
		while (!this.pq.isEmpty())
		{
			Edge edge = (Edge)this.pq.delMin();
			int num2 = edge.either();
			int num3 = edge.other(num2);
			if (!LazyPrimMST.s_assertionsDisabled && !this.marked[num2] && !this.marked[num3])
			{
				
				throw new AssertionError();
			}
			if (!this.marked[num2] || !this.marked[num3])
			{
				this.mst.enqueue(edge);
				this.weight += edge.weight();
				if (!this.marked[num2])
				{
					this.scan(edgeWeightedGraph, num2);
				}
				if (!this.marked[num3])
				{
					this.scan(edgeWeightedGraph, num3);
				}
			}
		}
	}
	
	
	private bool check(EdgeWeightedGraph edgeWeightedGraph)
	{
		double num = (double)0f;
		Iterator iterator = this.edges().iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			num += edge.weight();
		}
		double num2 = 1E-12;
		if (java.lang.Math.abs(num - this.weight()) > num2)
		{
			System.err.printf("Weight of edges does not equal weight(): %f vs. %f\n", new object[]
			{
				java.lang.Double.valueOf(num),
				java.lang.Double.valueOf(this.weight())
			});
			return false;
		}
		UF uF = new UF(edgeWeightedGraph.V());
		Iterator iterator2 = this.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			int num3 = edge2.either();
			int i = edge2.other(num3);
			if (uF.connected(num3, i))
			{
				System.err.println("Not a forest");
				return false;
			}
			uF.union(num3, i);
		}
		iterator2 = edgeWeightedGraph.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			int num3 = edge2.either();
			int i = edge2.other(num3);
			if (!uF.connected(num3, i))
			{
				System.err.println("Not a spanning forest");
				return false;
			}
		}
		iterator2 = this.edges().iterator();
		while (iterator2.hasNext())
		{
			Edge edge2 = (Edge)iterator2.next();
			uF = new UF(edgeWeightedGraph.V());
			Iterator iterator3 = this.mst.iterator();
			while (iterator3.hasNext())
			{
				Edge edge3 = (Edge)iterator3.next();
				int num4 = edge3.either();
				int i2 = edge3.other(num4);
				if (edge3 != edge2)
				{
					uF.union(num4, i2);
				}
			}
			iterator3 = edgeWeightedGraph.edges().iterator();
			while (iterator3.hasNext())
			{
				Edge edge3 = (Edge)iterator3.next();
				int num4 = edge3.either();
				int i2 = edge3.other(num4);
				if (!uF.connected(num4, i2) && edge3.weight() < edge2.weight())
				{
					System.err.println(new StringBuilder().append("Edge ").append(edge3).append(" violates cut optimality conditions").toString());
					return false;
				}
			}
		}
		return true;
	}
	
	
	private void scan(EdgeWeightedGraph edgeWeightedGraph, int num)
	{
		if (!LazyPrimMST.s_assertionsDisabled && this.marked[num])
		{
			
			throw new AssertionError();
		}
		this.marked[num] = true;
		Iterator iterator = edgeWeightedGraph.adj(num).iterator();
		while (iterator.hasNext())
		{
			Edge edge = (Edge)iterator.next();
			if (!this.marked[edge.other(num)])
			{
				this.pq.insert(edge);
			}
		}
	}
/*	[Signature("()Ljava/lang/Iterable<LEdge;>;")]*/
	public virtual Iterable edges()
	{
		return this.mst;
	}
	public virtual double weight()
	{
		return this.weight;
	}
	
	
	public LazyPrimMST(EdgeWeightedGraph ewg)
	{
		this.mst = new Queue();
		this.pq = new MinPQ();
		this.marked = new bool[ewg.V()];
		for (int i = 0; i < ewg.V(); i++)
		{
			if (!this.marked[i])
			{
				this.prim(ewg, i);
			}
		}
		if (!LazyPrimMST.s_assertionsDisabled && !this.check(ewg))
		{
			
			throw new AssertionError();
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		
		In i = new In(strarr[0]);
		EdgeWeightedGraph ewg = new EdgeWeightedGraph(i);
		LazyPrimMST lazyPrimMST = new LazyPrimMST(ewg);
		Iterator iterator = lazyPrimMST.edges().iterator();
		while (iterator.hasNext())
		{
			Edge obj = (Edge)iterator.next();
			StdOut.println(obj);
		}
		StdOut.printf("%.5f\n", new object[]
		{
			java.lang.Double.valueOf(lazyPrimMST.weight())
		});
	}
	
	static LazyPrimMST()
	{
		LazyPrimMST.s_assertionsDisabled = !ClassLiteral<LazyPrimMST>.Value.desiredAssertionStatus();
	}
}