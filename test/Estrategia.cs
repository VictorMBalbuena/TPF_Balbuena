
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> x=new Cola<ArbolGeneral<Planeta>>();

			x.encolar(arbol);
			x.encolar(null);

			int distancia=0;

			while (!x.esVacia())
			{
				
				ArbolGeneral<Planeta> nodoActual = x.desencolar();

				if (nodoActual != null)
				{
					if (nodoActual.getDatoRaiz().EsPlanetaDeLaIA())
					{
						return "consulta 1:"+ "La distancia es " + distancia+"\n";
					}
					else
					{
						foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos())
						{	
							x.encolar(hijo); 
						}			
					}
			    }
				else
				{
					distancia++;
					x.encolar(null);
				}	
			}
			return "No se encontro ningun planeta" ;
		}


		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> x=new Cola<ArbolGeneral<Planeta>>();
			x.encolar(arbol);
			int nivel=0;
			string mensaje="Consulta2=";
			while(!x.esVacia())
			{
				int elementos=x.cantElementos;
				nivel++;
				int cantidadPorNivel=0;
				while(elementos-->0)
				{
					ArbolGeneral<Planeta> nodoActual=x.desencolar();
					
					if (nodoActual.getDatoRaiz().Poblacion()>10) {
						cantidadPorNivel++;
					}
					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos()) 
					{
						x.encolar(hijo);
					}
				}
				mensaje+="Nivel "+nivel+":"+cantidadPorNivel+"--";
			}
			return mensaje;
		}


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> x=new Cola<ArbolGeneral<Planeta>>();
			x.encolar(arbol);
			int nivel=0;
			string mensaje="\nConsulta3:";
			while(!x.esVacia())
			{
				int elementos=x.cantElementos;
				nivel++;
				int cantidadPorNivel=0;
				int poblacionPorNivel=0;
				while(elementos-->0)
				{
					ArbolGeneral<Planeta> nodoActual=x.desencolar();
					
					cantidadPorNivel++;
					poblacionPorNivel +=nodoActual.getDatoRaiz().Poblacion();
					
					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos()) 
					{
						x.encolar(hijo);
					}
				}
				mensaje+="\nNivel "+nivel+":"+poblacionPorNivel/cantidadPorNivel;
			}
			return mensaje;
		}
		
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			
			List<Planeta> caminoHaciaRaiz = null;
			List<Planeta> caminoHaciaJugador = null;

			caminoHaciaRaiz = CaminoRaizIA(arbol, new List<Planeta>());
			caminoHaciaRaiz.Reverse();//la funcion reverse sirve para invertir el array,la lista

			caminoHaciaJugador = CaminoRaizJugador(arbol, new List<Planeta>());

			if (!arbol.getDatoRaiz().EsPlanetaDeLaIA())
			{
				Movimiento movARaiz = new Movimiento(caminoHaciaRaiz[0], caminoHaciaRaiz[1]);
				return movARaiz;
			}
			else
			{
				
				for(int index=0; index< caminoHaciaJugador.Count; index++)
				{
					if (caminoHaciaJugador[index].EsPlanetaDeLaIA() && 
							(caminoHaciaJugador[index+1].EsPlanetaNeutral()||caminoHaciaJugador[index+1].EsPlanetaDelJugador()))
					{
						Movimiento MovdeJugador = new Movimiento(caminoHaciaJugador[index], caminoHaciaJugador[index+1]);
						return MovdeJugador;
					}
				}
	
			}
			
			return null;
		}
		
		public List<Planeta> CaminoRaizIA(ArbolGeneral<Planeta> arbol, List<Planeta> caminoDeLaIA)
		{
			
			caminoDeLaIA.Add(arbol.getDatoRaiz());

			if (arbol.getDatoRaiz().EsPlanetaDeLaIA())
			{
				return caminoDeLaIA;
			}
			else
			{
				foreach(var hijo in arbol.getHijos())
				{
					
					List<Planeta> caminoAux = CaminoRaizIA(hijo, caminoDeLaIA);
						if (caminoAux != null)
						{
							return caminoAux;
						}
					
				}
				caminoDeLaIA.RemoveAt(caminoDeLaIA.Count-1);
			}
			return null;
		}
		
		public List<Planeta> CaminoRaizJugador(ArbolGeneral<Planeta> arbol, List<Planeta> caminoDeRaizAJugador)
		{

			caminoDeRaizAJugador.Add(arbol.getDatoRaiz());

			if (arbol.getDatoRaiz().EsPlanetaDelJugador())
			{
				return caminoDeRaizAJugador;
			}
			else
			{	
				foreach (var hijo in arbol.getHijos())
				{

					List<Planeta> caminoAux = CaminoRaizJugador(hijo, caminoDeRaizAJugador);
					if (caminoAux != null)
					{
						return caminoAux;
					}

				}
				caminoDeRaizAJugador.RemoveAt(caminoDeRaizAJugador.Count-1);

			}
			return null;
		}
	
	}
}
