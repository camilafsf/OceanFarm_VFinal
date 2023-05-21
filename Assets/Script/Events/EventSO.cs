using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "Criador de Eventos", menuName = "Criar Evento")]
public class EventSO : ScriptableObject
{
    public List<eventos> Eventos;
}
[Serializable]
public class eventos
{
   
    [Header("Apenas para o Inspector")]
    public string NomeDoEvento;
    [Header("--------------------------------------------------------------")]
    [Header("Se o Orador tiver nome")]
    public string[] nome;
    [TextArea(4, 6)]
    public string[] TextoDeCorpo;
    [Header("Se o Orador tiver Imagem")]
    public Sprite[] ImagemCentral;
    [Header("Imagem a ser exibida no corpo do texto")]
    public Sprite[] ImagemDeCorpo;
    [Header("Marque sen�o for evento com duas escolhas")]
    public bool BotaoContinuar;
    [Header("Se tiver nome Escolhas")]
    //public Button BotaoEscolha1;
    public string EfeitoBotao1;
    public string TextoEscolha1;
    [TextArea(4, 6)]
    public string Descri��oEscolha1;
    //public Button BotaoEscolha2;
    public string EfeitoBotao2;
    public string TextoEscolha2;
    [TextArea(4, 6)]
    public string Descri��oEscolha2;
    [Header("Data de ativa��o do Evento")]
    public int dia;
    public int mes;
    public int ano;
    [Header("se true todo ano na mesma data o evento repete")]
    public bool Repete;
    [Header("se true o evento surge em uma data aleatoria")]
    [Header("se marcar repeti��o e aleatoriedade ele vai repetir com base na data aleatoria como inicio")]
    
    public bool Aleatorio;
    
}
