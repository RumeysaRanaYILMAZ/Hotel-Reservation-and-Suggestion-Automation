using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
	public class nod<T>
	{
		public nod<T> parent;
		public nod<T> left;
		public nod<T> right;
		public T data;
		public nod(T ek)
		{
			this.data = ek;
		}
	}
	public class bintree<T> where T : IComparable<T>// Karşılaştırılabilir değişken alan ağaç
													//Bu ağaçta yalnızca karşılaştırılabilir değişken kullanıldığı için atanan generic tipin comparable olması gerekmektedir
	{

		private List<T> balanced;//Dengeleme için kullanılan liste
		public nod<T> root;
		public bintree()
		{
			root = null;
		}
		public void Add(T yeni)//Kullanılabilir add metodu
		{
			nod<T> tt = new nod<T>(yeni);
			this.add(tt);
		}
		private void add(nod<T> yeni)//add metodu -PRİVATE'TİR KULLANILMAZ
		{
			nod<T> c = root;
			if (root == null)
			{
				root = yeni;
			}
			else
			{
				while (c != null)
				{
					if (c.data.CompareTo(yeni.data) == -1)
					{
						if (c.right == null)
						{
							c.right = yeni;
							yeni.parent = c;
							c = null;
						}
						else
						{
							c = c.right;
						}
					}
					else
					{
						if (c.left == null)
						{
							c.left = yeni;
							yeni.parent = c;
							c = null;
						}
						else
						{
							c = c.left;
						}
					}
				}

			}
		}
		public bool isEmpty()//Ağacın boş olup olmadığını kontrol eder.
		{
			return root == null;
		}
		private void balance_adder(List<T> a)
		{//Verilen listeyi ağaca dengeli olacak şekilde ekleyen metod -RECURSİVE -PRİVATE'TİR KULLANILMAZ
			if (a.Count == 1)
			{
				this.Add(a[0]);
			}
			else if (a.Count != 0)
			{
				int pivot = a.Count / 2;
				this.Add(a[pivot]);
				balance_adder(a.GetRange(0, pivot));
				balance_adder(a.GetRange(pivot + 1, (a.Count - pivot + 1)));
			}
		}
		public void balance()//Ağacın dengeleme metodu
		{
			balanced = new List<T>();
			while (isEmpty() == false)
			{
				T temp = this.remove(root);
				balanced.Add(temp);
			}
			balanced.Sort();
			balance_adder(balanced);
		}
		private nod<T> ata(nod<T> a, nod<T> b)//Search metodunun yardımcı metodu
		{
			if (a == null && b != null)
			{
				return b;
			}
			else if (a != null && b == null)
			{
				return a;
			}
			else if (a != null && b != null)
			{
				return a;
			}
			else
			{
				return null;
			}
		}
		private nod<T> search(T ara, nod<T> bak)//arama metodu -RECURSİVE -PRİVATE'TİR KULLANILMAZ
		{
			if (bak == null)
			{
				return null;
			}
			else if (ara.Equals(bak.data))
			{
				return bak;
			}
			else
			{
				return ata(search(ara, bak.left), search(ara, bak.right));
			}
		}
		public void Uygula(nod<turistik> rr,List<otel> a){ 
			if(rr==null){

			}else{
				foreach(otel i in rr.data.oteller){
					a.Add(i);
				}
				Uygula(rr.left,a);
				Uygula(rr.right,a);
			}
		}
		public nod<T> search(T ara)//Kullanılabilir arama metodu
		{
			return search(ara, root);
		}
		public void Remove(T sil)//Kullanılabilir silme metodu
		{
			remove(search(sil));
		}
		private T remove(nod<T> e)//Ağaçtan eleman silmek için kullanılan metod -PRİVATE'TİR KULLANILMAZ
		{
			if (e == root)
			{
				nod<T> temp = root;
				if (root.right == null && root.left == null)
				{
					root = null;
					return temp.data;
				}
				else if (root.right == null && root.left != null)
				{
					root = root.left;
					return temp.data;
				}
				else if (e.right != null && e.left == null)
				{
					root = root.right;
					return temp.data;
				}
				else
				{
					nod<T> g = root.left;
					while (g.right != null)
					{
						g = g.right;

					}
					T temper = root.data;
					e.data = g.data;
					g.data = temper;
					return remove(g);
				}

			}
			else if (e.right == null && e.left == null)
			{
				if (e.parent.right == e)
				{
					nod<T> temp = e.parent.right;
					e.parent.right = null;
					return temp.data;
				}
				else
				{
					nod<T> temp = e.parent.left;
					e.parent.left = null;
					return temp.data;
				}
			}
			else if (e.right == null && e.left != null)
			{
				if (e.parent.right == e)
				{
					nod<T> temp = e.parent.right;
					e.parent.right = e.left;
					return temp.data;
				}
				else
				{
					nod<T> temp = e.parent.left;
					e.parent.left = e.left;
					return temp.data;
				}
			}
			else if (e.right != null && e.left == null)
			{
				if (e.parent.right == e)
				{
					nod<T> temp = e.parent.right;
					e.parent.right = e.right;
					return temp.data;
				}
				else
				{
					nod<T> temp = e.parent.left;
					e.parent.left = e.right;
					return temp.data;
				}
			}
			else
			{
				nod<T> g = e.right;
				while (g.left != null)
				{
					g = g.left;
				}
				T temp = e.data;
				e.data = g.data;
				g.data = temp;
				return remove(g);

			}
		}
	}
	public abstract class AbstractHeap
	{
		#region internal properties
		private int Capacity { get; set; }
		internal int Size { get; set; }
		internal oda[] Nodes { get; set; }
		#endregion

		#region constructors
		public AbstractHeap()
		{
			Capacity = 100;
			Size = 0;
			Nodes = new oda[Capacity];
		}
		#endregion

		#region helperMethods
		public void EnlargeIfNeeded()
		{
			if (Size == Capacity)
			{
				Capacity = 2 * Capacity;
				Array.Copy(Nodes, Nodes, Capacity);
			}
		}

		public int getLeftChildIndex(int parentIndex)
		{
			return 2 * parentIndex + 1;
		}

		public bool hasLeftChild(int parentIndex)
		{
			return getLeftChildIndex(parentIndex) < Size;
		}

		public oda leftChild(int index)
		{
			return Nodes[getLeftChildIndex(index)];
		}

		public int getRightChildIndex(int parentIndex)
		{
			return 2 * parentIndex + 2;
		}

		public bool hasRightChild(int parentIndex)
		{
			return getRightChildIndex(parentIndex) < Size;
		}

		public oda rightChild(int index)
		{
			return Nodes[getRightChildIndex(index)];
		}

		public int getParentIndex(int childIndex)
		{
			return (childIndex - 1) / 2;
		}

		public bool hasParent(int childIndex)
		{
			return getParentIndex(childIndex) >= 0;
		}

		public oda parent(int index)
		{
			return Nodes[getParentIndex(index)];
		}

		public void swap(int index1, int index2)
		{
			oda temp = Nodes[index1];
			Nodes[index1] = Nodes[index2];
			Nodes[index2] = temp;
		}

		#endregion

		#region available public methods

		/// <summary>
		/// Gets the minimum element at the root of the tree
		/// </summary>
		/// <returns>Int value of minimum element</returns>
		/// <exception cref="">InvalidOperationException when heap is empty</exception>
		public oda peek()
		{
			if (Size == 0)
				throw new InvalidOperationException("Heap is empty");

			return Nodes[0];
		}

		/// <summary>
		/// Removes the minimum element at the root of the tree
		/// </summary>
		/// <returns>Int value of minimum element</returns>
		/// <exception cref="">InvalidOperationException when heap is empty</exception>
		public oda pop()
		{
			if (Size == 0)
				throw new InvalidOperationException("Heap is empty");

			oda item = Nodes[0];
			Nodes[0] = Nodes[Size - 1];
			Size--;
			heapifyDown();
			return item;
		}

		/// <summary>
		/// Add a new item to heap, enlarging the array if needed
		/// </summary>
		/// <returns>void</returns>
		public void add(oda item)
		{
			EnlargeIfNeeded();
			Nodes[Size] = item;
			Size++;
			heapifyUp();
		}
		#endregion

		#region abstract methods
		internal abstract void heapifyUp();
		internal abstract void heapifyDown();
		#endregion
	}
	public class MinHeap : AbstractHeap
	{
		#region constructors
		public MinHeap() : base()
		{
		}
		#endregion

		#region internal methods
		internal override void heapifyDown()
		{
			int index = 0;
			while (hasLeftChild(index))
			{
				int smallerChildIndex = getLeftChildIndex(index);
				if (hasRightChild(index) && rightChild(index).fiyat < leftChild(index).fiyat)
				{
					smallerChildIndex = getRightChildIndex(index);
				}

				if (Nodes[smallerChildIndex].fiyat < Nodes[index].fiyat)
					swap(index, smallerChildIndex);
				else
					break;
				index = smallerChildIndex;
			}
		}
		internal override void heapifyUp()
		{
			int index = Size - 1;

			while (hasParent(index) && parent(index).fiyat > Nodes[index].fiyat)
			{
				swap(index, getParentIndex(index));
				index = getParentIndex(index);
			}
		}
		#endregion
	}
	public class Lineer_Hash
	{
		string[] alfabe ={"a","b","c","ç","d","e","f","g","ğ","h","ı","i","j","k","l","m",
						"n","o","ö","p","q","r","s","ş","t","u","ü","v","y","z","w","x"};
		public sehir[] table;
		public int size;
		public Lineer_Hash(int len)
		{
			table = new sehir[len];
			size = len;
		}
		private int hash_func(string a)
		{
			string b = a.ToLower();
			string c = "" + b[0];
			int i = 0;
			while (c != alfabe[i])
			{
				i += 1;
			}
			int sıra = (int)((size / alfabe.Length) * i);
			return sıra;
		}
		public void add(sehir k)
		{
			int index = hash_func(k.isim);
			if (table[index] == null)
			{
				table[index] = k;
			}
			else
			{
				while (table[index] != null)
				{
					index += 1;
				}
				table[index] = k;
			}
		}
		public void Remove(sehir s)
		{
			remove(s.isim);
		}
		private string remove(string k)
		{
			int index = hash_func(k);
			if (table[index].isim.Equals(k))
			{
				table[index] = null;
				return k;
			}
			else
			{
				string a = null;
				for (int i = index; i < table.Length; i++)
				{
					if (table[i].Equals(k))
					{
						table[i] = null;
						a = k;
					}
				}
				return a;
			}
		}
		public bool exist(sehir k)
		{
			int index = hash_func(k.isim);
			bool exist = false;
			for (int i = index; i < table.Length; i++)
			{
				if (table[i].Equals(k))
				{
					exist = true;
				}
			}
			return exist;
		}
	}
	public class Chain_Hash
	{
		string[] alfabe ={"a","b","c","ç","d","e","f","g","ğ","h","ı","i","j","k","l","m",
						"n","o","ö","p","q","r","s","ş","t","u","ü","v","y","z","w","x"};
		private List<ozellik>[] table;
		int size;
		public Chain_Hash(int len)
		{
			table = new List<ozellik>[len];
			for (int i = 0; i < len; i++)
			{
				table[i] = new List<ozellik>();
			}

			size = len;
		}
		private int hash_func(string o)
		{
			string b = o.ToLower();
			string c = "" + b[0];
			int i = 0;
			while (c != alfabe[i])
			{
				i += 1;
			}
			return i;
		}
		public void Add(ozellik o)
		{
			int index = hash_func(o.attributes);
			table[index].Add(o);
		}
		public void Remove(ozellik o)
		{
			int index = hash_func(o.attributes);
			table[index].Remove(o); ;
		}
		public ozellik Search(string s)
		{
			int index = hash_func(s);
			ozellik goal = null;
			foreach (ozellik oz in table[index])
			{
				if (oz.attributes.Equals(s))
				{
					goal = oz;
					break;
				}
			}
			return goal;
		}
	}
	public class sehir
	{
		public string isim;
		public bintree<turistik> yer_agaci;
		public sehir(string ad)
		{
			isim = ad;
			yer_agaci = new bintree<turistik>();
		}
	}
	public class oda
	{
		public string id;
		public otel sahip;
		public int yatak_say;
		public int kapasite;
		public int doluluk;
		public int fiyat;
		public string oda_tipi;
		public List<string> ozellik;
		public List<Üye> musteriler;
		public oda(string num, string ad, int yatak, int kap, int ucret)
		{
			id = num;
			yatak_say = yatak;
			oda_tipi = ad;
			kapasite = kap;
			doluluk = 0;
			fiyat = ucret;
			ozellik = new List<string>();
			musteriler = new List<Üye>();
		}
		public bool isfull()
		{
			if (doluluk == kapasite)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void otele_ekle(otel t)
		{
			sahip = t;
		}
	}
	public class kullanıcı
	{
		public string uye_tip;
		private string nickname;
		private string password;
		public string Password { get => password; set => password = value; }
		public string Kullanıcı_adı { get => nickname; set => nickname = value; }

		public kullanıcı(string tip,string name, string pass)
		{
			uye_tip = tip;
			password = pass;
			Kullanıcı_adı = name;
		}
	}
	public class Üye : kullanıcı
	{
		public string isim;
		public int yas;
		public int maas;
		public string meslek;
		public string evli;
		public string cinsiyet;
		public List<oda> rezervasyonlar;
		public Üye(string tip,string nickname, string name, string pass) : base(tip,nickname, pass)
		{
			rezervasyonlar = new List<oda>();
			isim = name;
		}
	}
	public class admin : kullanıcı
	{
		public static int kar;
		string isim;
		public admin(string tip, string ad,string name, string pass) : base(tip,ad, pass)
		{
			isim = ad;
		}
		public void yer_ekle(sehir s, turistik t)
		{
			s.yer_agaci.Add(t);
		}
		public void otel_ekle(turistik t, string isim, string vil)
		{
			t.Add(new otel(isim, vil));
		}
		public void otel_ekle(turistik t, string isim)
		{
			t.Add(new otel(isim));
		}
		public otel otel_arama(string isim, Lineer_Hash f)
		{
			turistik t = null;
			foreach (sehir city in f.table)
			{
				turistik turi = tur_dondur(city.yer_agaci.root, isim);
				if (turi != null)
				{
					t = turi;
					break;
				}
			}
			otel otelet = t.otel_arama(isim);
			return otelet;
		}
		public bool otel_sil(Chain_Hash a, Lineer_Hash f, otel otelis)
		{
			turistik turi = null;
			bool nullear = false;
			foreach (sehir city in f.table)
			{
				turi = tur_dondur(city.yer_agaci.root, otelis.isim);
				if (turi != null)
				{
					nullear = true;
					turi.Remove(otelis, a);
					break;
				}
			}
			return nullear;
		}
		private turistik dondur(turistik a, turistik b)
		{
			if (a == null && b == null)
			{
				return null;
			}
			else if (a == null && b != null)
			{
				return b;
			}
			else if (a != null && b == null)
			{
				return a;
			}
			else
			{
				return a;
			}
		}
		private turistik tur_dondur(nod<turistik> a, string b)
		{
			if (a == null)
			{
				return null;
			}
			else if (a.data.otel_bool(b) == true)
			{
				return a.data;
			}
			else
			{
				return dondur(tur_dondur(a.left, b), tur_dondur(a.right, b));
			}
		}


	}
	public class ozellik
	{
		public string attributes;
		public List<otel> otels;
		public ozellik(string isim)
		{
			attributes = isim;
			otels = new List<otel>();
		}
		public string toString()
		{
			return attributes;
		}
	}
	public class otel
	{
		public string isim;
		public string ilce;
		public string yer_isim;
		public List<string> bilgiler;
		public List<oda> odalar;
		public List<oda> rezerved;
		public List<oda> non_rezerved;
		public otel(string ad, string vil)
		{
			odalar = new List<oda>();
			non_rezerved = new List<oda>();
			bilgiler = new List<string>();
			isim = ad;
			ilce = vil;
		}
		public otel(string ad)
		{
			bilgiler = new List<string>();
			odalar = new List<oda>();
			non_rezerved = new List<oda>();
			isim = ad;
		}
		public bool rezervasyon(string tip, Üye k)
		{
			oda aranan = oda_ara(tip, non_rezerved);
			if (aranan == null || aranan.isfull() == true)
			{
				return false;
			}
			else
			{
				int pay = aranan.fiyat / 10;
				admin.kar += pay;
				k.rezervasyonlar.Add(aranan);
				aranan.musteriler.Add(k);
				aranan.doluluk += 1;
				return true;
			}
		}
		public void oda_ekle(oda o)
		{
			odalar.Add(o);
			non_rezerved.Add(o);
			o.otele_ekle(this);
		}
		public void oda_sil(string k)
		{
			oda aranan = oda_ara(k, odalar);
			if (aranan != null)
			{
				foreach (Üye uy in aranan.musteriler)
				{
					uy.rezervasyonlar.Remove(aranan);
				}
				odalar.Remove(aranan);
				if (non_rezerved.Contains(aranan))
				{
					non_rezerved.Remove(aranan);
				}
			}
		}
		public oda oda_ara(string isim, List<oda> liste)
		{
			oda hedef = null;
			foreach (oda i in liste)
			{
				if (isim.Equals(i.oda_tipi))
				{
					hedef = i;
				}
			}
			return hedef;
		}
		public string toString()
		{
			return isim + " , " + ilce;
		}
	}
	public class turistik : IComparable<turistik>
	{
		public string isim;
		public List<otel> oteller;
		public turistik(string ad)
		{
			isim = ad;
			oteller = new List<otel>();
		}
		public void Add(otel ek)
		{
			oteller.Add(ek);
		}
		public void Remove(otel sil, Chain_Hash a)
		{
			while (sil.odalar.Count != 0)
			{
				sil.oda_sil(sil.odalar.Last().oda_tipi);
			}
			while (sil.bilgiler.Count != 0)
			{
				a.Search(sil.bilgiler.First()).otels.Remove(sil);
			}
		}
		public otel otel_arama(string a)
		{
			otel hedef = null;
			foreach (otel ot in oteller)
			{
				if (ot.isim.Equals(a))
				{
					hedef = ot;
					break;
				}
			}
			return hedef;
		}
		public bool otel_bool(string a)
		{
			return otel_arama(a) != null;
		}
		public string toString()
		{
			return isim;
		}
		public int CompareTo(turistik other)
		{
			return this.isim.CompareTo(other.isim);
		}
	}
	public class frekans
	{
		public otel t;
		public double frek;
		public frekans(otel olet)
		{
			t = olet;
			frek = 0;
		}
	}
	public class kombinasyon : IComparable
	{
		public List<otel> komb;
		public double f;
		public kombinasyon(List<otel> komb1)
		{
			komb = komb1;
		}

		public int CompareTo(object obj)
		{
			kombinasyon a = (kombinasyon)obj;
			if (this.f > a.f)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}
	public class apriori
	{
		public List<otel>[] sınıflama = new List<otel>[5];
		List<Üye> kullanıcılar;
		List<frekans> freks = new List<frekans>();
		List<List<otel>> uzay;
		static List<List<otel>> comb;
		public bool[] used;
		public apriori(List<Üye> users)
		{
			kullanıcılar = users;
			uzay = new List<List<otel>>();
		}
		private void GetComb(List<otel> arr, int colindex, List<otel> c)
		{

			if (colindex >= arr.Count)
			{
				comb.Add(new List<otel>(c));
				return;
			}
			for (int i = 0; i < arr.Count; i++)
			{
				if (!used[i])
				{
					used[i] = true;
					c.Add(arr[i]);
					GetComb(arr, colindex + 1, c);
					c.RemoveAt(c.Count - 1);
					used[i] = false;
				}
			}
		}
		public List<List<otel>> GetCombinationSample(int i)
		{
			List<otel> fre = new List<otel>();
			foreach (frekans f in freks)
			{
				fre.Add(f.t);
			}
			used = new bool[freks.Count];
			used.Select(x => x = false);
			comb = new List<List<otel>>();
			List<otel> c = new List<otel>();
			GetComb(fre, 0, c);
			foreach (List<otel> son in comb)
			{
				if (son.Count != i)
				{
					comb.Remove(son);
				}

			}
			return comb;
		}
		public List<otel> calıstır(Üye tav){
			list_olustur(tav);
			GetCombinationSample(2);
			List<otel> tavsiye=frekle();
			return tavsiye;
		}
		public List<otel> frekle()
		{
			List<kombinasyon> cc = new List<kombinasyon>();
			foreach (List<otel> tt in GetCombinationSample(3))
			{
				cc.Add(new kombinasyon(tt));
			}
			foreach (kombinasyon aa in cc)
			{
				foreach (List<otel> tt in sınıflama)
				{
					if (var_mı(aa.komb, tt) == true)
					{
						aa.f += 1;
					}
				}
			}
			cc.Sort();
			return cc.Last().komb;
		}
		public bool var_mı(List<otel> vd, List<otel> sh)
		{
			if (sh.Count == 2)
			{
				if (vd.Contains(sh[0]) && vd.Contains(sh[1]))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if (sh.Count == 3)
			{
				if (vd.Contains(sh[0]) && vd.Contains(sh[1]) && vd.Contains(sh[2]))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

		}
		public void list_olustur(Üye uy)
		{
			foreach (Üye user in kullanıcılar)
			{
				if (uy.cinsiyet.Equals(user.cinsiyet))
				{
					foreach (oda i in user.rezervasyonlar)
					{
						sınıflama[0].Add(i.sahip);
					}
				}
				if (uy.evli.Equals(user.evli))
				{
					foreach (oda i in user.rezervasyonlar)
					{
						sınıflama[1].Add(i.sahip);
					}
				}
				if (Math.Abs(user.maas - uy.maas) < (uy.maas / 10))
				{
					foreach (oda i in user.rezervasyonlar)
					{
						sınıflama[2].Add(i.sahip);
					}
				}
				if (Math.Abs(user.yas - uy.yas) < 5)
				{
					foreach (oda i in user.rezervasyonlar)
					{
						sınıflama[3].Add(i.sahip);
					}
				}
				if (uy.meslek.Equals(user.meslek))
				{
					foreach (oda i in user.rezervasyonlar)
					{
						sınıflama[4].Add(i.sahip);
					}
				}
			}
			foreach (List<otel> tt in sınıflama)
			{
				foreach (otel i in tt)
				{
					exist_otel(i);
				}
			}
			foreach (frekans fr in freks)
			{
				fr.frek = Math.Round((fr.frek / freks.Count), 2);
				if (fr.frek < 0.3)
				{
					freks.Remove(fr);
				}
			}
		}
		public void exist_otel(otel h)
		{
			bool exist = false;
			foreach (frekans fr in freks)
			{
				if (h.isim.Equals(fr.t))
				{
					exist = true;
					fr.frek += 1;
					break;
				}
			}
			if (exist == false)
			{
				freks.Add(new frekans(h));
			}
		}
	}
	class test
	{
		public static Lineer_Hash sehirler;
		public static Chain_Hash specials;
		public static List<oda> tum_odalar;
		public static List<turistik> tum_yerler;
		public static List<otel> tum_oteller;
		public static List<kullanıcı> tum_kullan;
		public const string oda_dat = "C:\\Users\\zzuurr\\Desktop\\data\\odalar.dat";
		public const string otel_dat = "C:\\Users\\zzuurr\\Desktop\\data\\oteller.dat";
		public const string yer_dat = "C:\\Users\\zzuurr\\Desktop\\data\\yerler.dat";
		public const string sehir_dat = "C:\\Users\\zzuurr\\Desktop\\data\\sehirler.dat";
		public const string ozellik_dat = "C:\\Users\\zzuurr\\Desktop\\data\\ozellikler.dat";
		public const string kullanıcı_dat = "C:\\Users\\zzuurr\\Desktop\\data\\kullanıcılar.dat";


		static void lineChanger(string newText, string fileName, int line_to_edit)
		{
			string[] arrLine = File.ReadAllLines(fileName);
			arrLine[line_to_edit - 1] = newText;
			File.WriteAllLines(fileName, arrLine);
		}
		public static List<otel> arama(string sorgu){
			List<otel> otel_sor;
			otel hedef = otel_ara(sorgu);
			sehir s = sehir_ara(sorgu);
			turistik travel = turist_ara(sorgu);
			if (hedef!=null){
				otel_sor = new List<otel>();
				otel_sor.Add(hedef);
				return otel_sor;
			}else if(turist_ara(sorgu)!=null){
				return travel.oteller;
			}else if(s!=null){
				otel_sor = new List<otel>();
				s.yer_agaci.Uygula(s.yer_agaci.root, otel_sor);
				return otel_sor;
			}else{
				return null;
			}
		}
		private static sehir sehir_ara(string city){
			sehir citt = null;
			for(int i=0;i<sehirler.size;i++){
				if(sehirler.table[i] != null)
				{
					if (sehirler.table[i].isim.Equals(city))
					{
						citt = sehirler.table[i];
						break;
					}
				}
				
			}
			return citt;
		}
		private static turistik turist_ara(string goal){
			turistik hedef = null;
			foreach (turistik ot in tum_yerler)
			{
				if (ot.isim.Equals(goal))
				{
					hedef = ot;
					break;
				}
			}
			return hedef;
		}
		private static otel otel_ara(string a)
		{
			otel hedef = null;
			foreach (otel ot in tum_oteller)
			{
				if (ot.isim.Equals(a))
				{
					hedef = ot;
					break;
				}
			}
			return hedef;
		}
		public static void Baslat()
		{
			StreamReader objInput = new StreamReader(oda_dat, System.Text.Encoding.Default);
			string contents = objInput.ReadLine();
			string[] split = Regex.Split(contents, "-", RegexOptions.None);
			tum_odalar = new List<oda>();
			while (contents != null)
			{
				split = Regex.Split(contents, "-", RegexOptions.None);
				string id = split[0];
				string oda_tip = split[1];
				string[] split2 = split[2].Split('.');
				int yataksay = Convert.ToInt32(split2[0]);
				int kapasit = Convert.ToInt32(split2[1]);
				int ucret = Convert.ToInt32(split2[2]);
				tum_odalar.Add(new oda(id, oda_tip, yataksay, kapasit, ucret));
				contents = objInput.ReadLine();
			}
			StreamReader streamr = new StreamReader(otel_dat, System.Text.Encoding.Default);
			string okuma = streamr.ReadLine();
			string[] splinter = okuma.Split('!');
			tum_oteller = new List<otel>();
			while (okuma != null)
			{
				splinter = okuma.Split('!');
				string isim = splinter[0];
				string[] splint = splinter[1].Split(',');
				string yer = splint[1];
				List<string> bilg = splinter[2].Split(',').ToList();
				string[] arr = splinter[3].Split(',');
				List<oda> otel_oda = new List<oda>();
				foreach (string a in arr)
				{
					foreach (oda od in tum_odalar)
					{
						if (a.Equals(od.id))
						{
							otel_oda.Add(od);
						}
					}
				}
				okuma = streamr.ReadLine();
				otel yeni = new otel(isim);
				yeni.bilgiler = bilg;
				yeni.odalar = otel_oda;
				yeni.yer_isim = yer;
				foreach(oda sah in yeni.odalar){
					sah.sahip = yeni;
				}
				tum_oteller.Add(yeni);
			}
			StreamReader stream_yer = new StreamReader(yer_dat, System.Text.Encoding.Default);
			string okuma_yer = stream_yer.ReadLine();
			string[] split_yer = okuma_yer.Split('!');
			tum_yerler = new List<turistik>();
			while (okuma_yer != null)
			{
				split_yer = okuma_yer.Split('!');
				string ad = split_yer[0];
				string[] arr1 = split_yer[1].Split(',');
				List<otel> otel_yer = new List<otel>();
				foreach (string a in arr1)
				{
					foreach (otel ot in tum_oteller)
					{
						if (a.Equals(ot.isim))
						{
							otel_yer.Add(ot);
						}
					}
				}
				turistik yenı_yer = new turistik(ad);
				yenı_yer.oteller = otel_yer;
				tum_yerler.Add(yenı_yer);
				okuma_yer = stream_yer.ReadLine();
			}
			StreamReader sehirici = new StreamReader(sehir_dat, System.Text.Encoding.Default);
			string okuma_sehir = sehirici.ReadLine();
			string[] split_s = okuma_sehir.Split('!');
			sehirler = new Lineer_Hash(32);
			while (okuma_sehir != null)
			{
				split_s = okuma_sehir.Split('!');
				string ad1 = split_s[0];
				string[] arr2 = split_s[1].Split(',');
				bintree<turistik> place = new bintree<turistik>();
				foreach (string a in arr2)
				{
					foreach (turistik tur in tum_yerler)
					{
						if (tur.isim.Equals(a))
						{
							place.Add(tur);
						}
					}
				}
				sehir city = new sehir(ad1);
				city.yer_agaci = place;
				sehirler.add(city);
				okuma_sehir = sehirici.ReadLine();
			}
			StreamReader ozellik = new StreamReader(ozellik_dat, System.Text.Encoding.Default);
			string attreb = ozellik.ReadLine();
			specials = new Chain_Hash(32);
			while (attreb != null)
			{
				string[] split_oz = attreb.Split('-');
				string oz = split_oz[0];
				string[] split_otel = split_oz[1].Split(',');
				ozellik ekleme = new ozellik(oz);
				List<otel> ek1 = new List<otel>();
				foreach (string a in split_otel)
				{
					foreach (otel tel in tum_oteller)
					{
						if (tel.isim.Equals(a))
						{
							ek1.Add(tel);
						}
					}
				}
				ekleme.otels = ek1; ;
				specials.Add(ekleme);
				attreb = ozellik.ReadLine();
			}
			tum_kullan = new List<kullanıcı>();
			StreamReader users = new StreamReader(kullanıcı_dat, System.Text.Encoding.Default);
			string kayıt = users.ReadLine();
			while (kayıt != null)
			{
				string[] split_us = kayıt.Split('!');
				string user_info = split_us[0];
				string[] bilgiler = user_info.Split(',');
				if(bilgiler[0].Equals("admin")){
					admin yonet = new admin(bilgiler[0],bilgiler[1], bilgiler[3], bilgiler[2]);
					tum_kullan.Add(yonet);
				}if(bilgiler[0].Equals("uye")){
					Üye kullan = new Üye(bilgiler[0], bilgiler[1], bilgiler[3], bilgiler[2]);
					kullan.cinsiyet = bilgiler[5];
					kullan.yas = Convert.ToInt32(bilgiler[4]);
					kullan.meslek = bilgiler[7];
					kullan.evli = bilgiler[6];
					kullan.maas = Convert.ToInt32(bilgiler[8]);
					if (split_us.Length != 1)
					{
						string[] split_pas = split_us[1].Split(',');
						foreach (string a in split_pas)
						{
							foreach (oda od in tum_odalar)
							{
								if (od.id.Equals(a))
								{
									kullan.rezervasyonlar.Add(od);
								}
							}
						}
					}
					tum_kullan.Add(kullan);
				}
				
				kayıt = users.ReadLine();
			}
		}
	}

	static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
			test.Baslat();
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(test.sehirler,test.specials));
        }
    }
}
