﻿namespace Flap;

public partial class MainPage : ContentPage
{
	
const int gravidade = 40;
const int tempoEntreFrames =1000;
bool estaMorto = true;
double larguraJanela;
double alturaJanela;
double velocidade;
double frameGameOver;
double Desenha;
	public MainPage()
	{
		InitializeComponent();
		
	}


	void AplicaGravidade()
	{
		passaro.TranslationY += gravidade;
	}
	
	async Task Desenhar ()
	{
      while (! estaMorto)
	  {
		 AplicaGravidade();
		 await Task.Delay(tempoEntreFrames);
		 GerenciaCanos();
	  }
	}

    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		larguraJanela=w;
		alturaJanela=h;
    }

	void GerenciaCanos()
	{
		imgcanoum.TranslationX-= velocidade;
		imgcanodois.TranslationX-= velocidade;
		if (imgcanodois.TranslationX<=-larguraJanela)
		{
			imgcanodois.TranslationX=0;
			imgcanoum.TranslationX=0;

		}
	}
			void OnGameOverClicked(object s, ItemTappedEventArgs a)
	{
		frameGameOver.IsVisible=false;
		Inicializar();
		Desenha();
	}



}
