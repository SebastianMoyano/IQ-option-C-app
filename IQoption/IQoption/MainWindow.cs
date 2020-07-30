using System;
using Gtk;
using System.Collections.Generic;
using IqOptionApi;
using IqOptionApi.Models;
using System.Threading.Tasks;
using System.Globalization;

public partial class MainWindow : Gtk.Window
{
	private global::Gtk.HBox hbox3;
	
	private global::Gtk.ComboBox tipo;
	private global::Gtk.Button Login;
	private global::Gtk.Button buy;
	private global::Gtk.Button sell;
	private global::Gtk.ComboBox Tiempo;
	private global::Gtk.ComboBox testentry;
	private global::Gtk.ComboBox Factor;
	/// <summary>
    /// aqui van los nombres para la compra
    /// </summary>
	Label uno1;
	Label dos2;
	Label tres3;

	List<Label> test;
	List<int> idmonedas;
	readonly int cantidad = 2;
	List<Entry> arreglo;
	List<Label> Labels;
	List<IqOptionClient> usuarios;
	List<decimal> porcentajes;
	private int numero;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
	{

		//Build();
		Build2();

	}
	protected virtual void Build2()
	{
		//global::Stetic.Gui.Initialize(this);
		// Widget MainWindow

		this.Name = "IQtrade";
		this.Title = global::Mono.Unix.Catalog.GetString("IQtrade");
		this.WindowPosition = ((WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild

		this.hbox3 = new HBox();

		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		arreglo = new List<Entry>();
		Labels = new List<Label>();
		test = new List<Label>();

		for (int i = 0; i < cantidad; i++)
		{

			Box vbox = new VBox();
			Label userL = new Label();
			userL.Text = "Usuario";
			Label pssL = new Label();
			pssL.Text = "Contraseña";
			Label porceL = new Label();
			porceL.Text = "Porcentaje(max 5%)";
			Label info = new Label();
			info.Text = "";
			Entry us = new Entry();
			Entry pass = new Entry();
			Entry porcentaje = new Entry();
			pass.IsEditable = true;
			pass.Visibility = false;
			pass.InvisibleChar = '●';
			vbox.Add(userL);
			vbox.Add(us);
			vbox.Add(pssL);
			vbox.Add(pass);
			vbox.Add(porceL);
			vbox.Add(porcentaje);
			arreglo.Add(us);
			arreglo.Add(pass);
			arreglo.Add(porcentaje);
			Labels.Add(userL);
			Labels.Add(pssL);
			Labels.Add(porceL);
			test.Add(info);
			this.hbox3.Add(vbox);
		}

		this.tipo = global::Gtk.ComboBox.NewText();
		Button Hide = new Button();
		Hide.Label = "Show/Hide";
		Box v2box = new VBox();
		this.Login = new Button();
		this.Login.Image = Image.LoadFromResource("IQoption.login.png");
		this.Login.Relief = ((global::Gtk.ReliefStyle)(2));

		this.tipo.AppendText(global::Mono.Unix.Catalog.GetString("Real"));
		this.tipo.AppendText(global::Mono.Unix.Catalog.GetString("Practice"));
		this.tipo.Active = 1;
		v2box.Add(Hide);
		v2box.Add(this.tipo);
		foreach (Label element in this.test)
		{
			v2box.Add(element);
		}
			
		v2box.Add(this.Login);
		this.hbox3.Add(v2box);
		///////////////////////////////
		this.Tiempo = global::Gtk.ComboBox.NewText();
		this.Tiempo.AppendText("1");
		this.Tiempo.AppendText("2");
		this.Tiempo.AppendText("3");
		this.Tiempo.AppendText("4");
		this.Tiempo.AppendText("5");
		this.Tiempo.Active = 0;

		var monedas = new List<string>() { "EURUSD", "EURGBP", "GBPJPY", "EURJPY", "GBPUSD", "USDJPY", "AUDCAD", "NZDUSD", "USDRUB", "USDCHF", "XAUUSD", "EURUSD-OTC", "EURGBP-OTC", "USDCHF-OTC", "NZDUSD-OTC", "GBPUSD-OTC", "AUDCAD-OTC", "AUDUSD", "USDCAD", "AUDJPY", "GBPCAD", "GBPCHF", "GBPAUD", "EURCAD", "CHFJPY", "CADCHF", "EURAUD", "USDNOK", "EURNZD", "USDSEK", "USDTRY", "BTCUSD", "XRPUSD", "ETHUSD", "LTCUSD", "DSHUSD", "BCHUSD", "OMGUSD", "ZECUSD", "ETCUSD", "BTGUSD", "QTMUSD", "TRXUSD", "EOSUSD", "USDINR", "USDPLN", "USDBRL", "USDZAR", "USDSGD", "USDHKD" };
		this.idmonedas = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 10, 72, 74, 76, 77, 78, 80, 81, 86, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 168, 212, 219, 220, 816, 817, 818, 819, 821, 824, 825, 826, 829, 837, 845, 858, 864, 865, 866, 867, 868, 892, 893};
	
		this.testentry = global::Gtk.ComboBox.NewText();
		this.Factor = global::Gtk.ComboBox.NewText();
		this.Factor.AppendText("1");
		this.Factor.AppendText("2");
		this.Factor.AppendText("3");
		for (int i = 0; i < 50; i++)
		{
			this.testentry.AppendText(monedas[i]);
		}
		this.testentry.Active = 0;
		this.Factor.Active = 0;
		Box v3box = new VBox();
		this.buy = new Button();
		this.buy.Image = Image.LoadFromResource("IQoption.COMPRA.png");
		this.buy.Relief = ((global::Gtk.ReliefStyle)(2));
	
		this.sell = new Button();
		this.sell.Image = Image.LoadFromResource("IQoption.VENTA.png");
		this.sell.Relief = ((global::Gtk.ReliefStyle)(2));
		this.uno1 = new Label();
		this.dos2 = new Label();
		this.tres3 = new Label();
		uno1.Text = "Moneda";
		dos2.Text = "Minuto de Compra";
		tres3.Text = "Factor multiplicador";
		v3box.Add(this.uno1);
		v3box.Add(this.testentry);
		v3box.Add(this.dos2);
		v3box.Add(this.Tiempo);
		v3box.Add(this.tres3);
		v3box.Add(this.Factor);
		v3box.Add(this.buy);
		v3box.Add(this.sell);
		this.hbox3.Add(v3box);

		////////////////////////////////
		this.Add(this.hbox3);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 578;
		this.DefaultHeight = 300;
		this.uno1.Hide();
		this.dos2.Hide();
		this.tres3.Hide();
		this.Factor.Hide();
		this.Tiempo.Hide();
		this.buy.Hide();
		this.sell.Hide();
		this.testentry.Hide();
		this.Show();

		this.DeleteEvent += new DeleteEventHandler(this.OnDeleteEvent);
		this.Login.Clicked += new EventHandler(this.OnButton3Clicked);
		Hide.Clicked += new EventHandler(this.ButtonHide);
		this.buy.Clicked += new EventHandler(this.Comprar);
		this.sell.Clicked += new EventHandler(this.Vender);
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}



	protected void OnButton3Clicked(object sender, EventArgs e)
	{
		
		ShowHide(false);
		this.Resize(100, 100);

		usuarios = new List<IqOptionClient>();
		porcentajes = new List<decimal>();


		for (int i = 0; i < cantidad * 3; i += 3)
		{
			var trader = new IqOptionClient(arreglo[i].Text, arreglo[i + 1].Text);
			usuarios.Add(trader);
            decimal valor;
			var text = arreglo[i + 2].Text.Replace(',', '.');
			//////
			///Limitar valor % /////////////////////////
			if (decimal.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture) > 6)
            {
				valor = 6;
            }
            else
            {
				valor = decimal.Parse(arreglo[i + 2].Text);

			}
			//////////////////////////////////////////////
            /// se agrega a los porcentajes
			porcentajes.Add(valor/ 100);

		}
		this.numero = this.tipo.Active;
		todo();
		
	}
	protected void ButtonHide(object sender, EventArgs e)
	{
		if(this.Login.Visible == false)
        {
			ShowHide(true);
			this.Resize(300, 200);
		}
        else
        {
			ShowHide(false);
			this.Resize(100, 100);
		}
		

	}
	public async Task todo()
	{
		//Runsample();

		for (int i = 0; i < cantidad ; i ++)
		{
			var check = await usuarios[i].ConnectAsync();
			//usuarios[i].IsConnected;
			if (check)
            {
				var traderP = await usuarios[i].GetProfileAsync();
				var traderL = Valores(traderP);

				if (this.numero == 0)
				{

					await usuarios[i].ChangeBalanceAsync(traderL.Item2);

				}
				else
				{
					//this.test.Text = traderL.Item2.ToString();
					await usuarios[i].ChangeBalanceAsync(traderL.Item1);
				}
				this.test[i].Text = "Conectado  cuenta: " + (i + 1).ToString() + "\n"; 
				
			}
            else
			{
				this.test[i].Text = "Error cuenta: " + (i + 1).ToString() + "\n";
				
			}

		}

			


	}

	public Tuple<long, long> Valores(Profile profile)
	{


		//this.conection.Text = "1";
		long idP = 0;
		long idR = 0;

		for (int i = 0; i < 5; i++)
		{

			string test = profile.Balances[i].Currency.ToString();
			string test2 = profile.Balances[i].Type.ToString();
			long id = profile.Balances[i].Id;

			//this.test.Text = test2;
			if (test == "USD")
			{
				//this.conection.Text = test2;
				if (test2 == "Practice")
				{					
					idP = id;
				}
				else
				{
					idR = id;
				}

			}


		}
		
		//this.test.Text = idR.ToString() + " P: " + idP.ToString();
		return Tuple.Create(idP, idR);
	}
	public void ShowHide(bool boleano)
	{
		for (int i = 0; i < cantidad * 3; i += 3)
		{
			arreglo[i].Visible = boleano;
			Labels[i].Visible = boleano;
			arreglo[i+1].Visible = boleano;
			Labels[i+1].Visible = boleano;
			arreglo[i+2].Visible = boleano;
			Labels[i+2].Visible = boleano;
		}
		
		this.Login.Visible = boleano;
		this.tipo.Visible = boleano;
		////////////////////////
		this.uno1.Visible = !boleano;
		this.dos2.Visible = !boleano;
		this.tres3.Visible = !boleano;
		this.Factor.Visible = !boleano;
		this.buy.Visible = !boleano;
		this.sell.Visible = !boleano;
		this.Tiempo.Visible = !boleano;
		this.testentry.Visible = !boleano;
	}

	public void Comprar(object sender, EventArgs e)
	{
		ActionAsync(0);
	}
	public void Vender(object sender, EventArgs e)
	{
		ActionAsync(1);

	}
	public void ActionAsync(int tipo)
    {
		DateTime exp;
		DateTime val = DateTime.Now;

		if (val.Second % 60 > 30)
		{
			var s = val.AddSeconds(60 - val.Second);
			exp = s.AddMinutes(1 + this.Tiempo.Active);

		}
		else
		{
			var s = val.AddSeconds(60 - val.Second);
			exp = s.AddMinutes(this.Tiempo.Active);


		}

		
		for (int i = 0; i < cantidad; i++)
		{
			/////////////////////////////
			///asi accedes a los valores de activepair segun el numero?/////
			////////////////
			buyAscAsync(tipo, i, exp);
		}

	}
	public async Task buyAscAsync(int tipo,int i,DateTime exp)
    {
		
		IqOptionApi.Models.BinaryOptions.BinaryOptionsResult result;
		ActivePair _item = (ActivePair)this.idmonedas[this.testentry.Active];
		var cantidad = usuarios[i].Profile.Balance * porcentajes[i] * (this.Factor.Active+1);

		if (tipo == 1)
		{
			result = await usuarios[i].BuyAsync(_item, (int)cantidad, OrderDirection.Put, exp);
		}
		else
		{
			result = await usuarios[i].BuyAsync(_item, (int)cantidad, OrderDirection.Call, exp);
		}


		if (result.ErrorMessage == null)
		{
			this.test[i].Text = usuarios[i].Profile.FirstName.ToString() + "\n"+ "Cantidad:"+result.Amount.ToString() + "\n"+result.OrderDirection.ToString();

		}
		else
		{
			this.test[i].Text = result.ErrorMessage;
		}

	}

}
