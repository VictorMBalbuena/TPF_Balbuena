
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
		
			return null;
		}
	
	}
}
