using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{

    class PongBall
    {
        void returnBallXY()
        {
            /*
            registersymbol(aobBallXY)
            */
        }

        void SchreibeNeueBallposition()
        {
            /*
            call ballPhysik
            fld [ballX]
            fstp [ecx]
            fld [ballY]
            fstp dword ptr [ecx+04]
             */
            ballX = 0;
            ballY = 0;
        }

        void newmemBallXY() 
        {
            SchreibeNeueBallposition();

            /*
            //original code
            fld dword ptr [ecx]
            fld dword ptr [ecx+04]
            //
            */

            returnBallXY();
        }

        void aobBallXY()
        {
            newmemBallXY();
        }

        void returnPlayerY()
        {
            /*
            registersymbol(aobPlayerY)
            */
        }

        void LesePlayerY()
        {
            /*
            fld dword ptr [edi+04]
            fstp [spielerY]
             */
        }

        void newmemPlayerY() 
        {
            LesePlayerY();

            /*
            //original code
            fstp dword ptr [edi+04]
            fld dword ptr [esi+10]
            //
            */

            returnPlayerY();
        }

        void aobPlayerY()
        {
            newmemPlayerY();
            /*
             nop
             */
        }

        void returnBotY()
        {
            /*
            registersymbol(aobBotY)
            */
        }

        void LeseBotY()
        {
            /*
            fld dword ptr [ecx+10]
            fstp [botY]
             */
        }

        void newmemBotY() 
        {
            LeseBotY();

            /*
            //original code
            fld dword ptr [ecx+10]
            fcomip st(0),st(1)
            //
            */

            returnBotY();
        }

        void aobBotY()
        {
            newmemBotY();
        }

        void returnBotPunkte()
        {
            /*
             registersymbol(aobBotPunkte)
             */
        }

        void SetzeUndPruefeBotScore()
        {
            /*
            // setze und pruefe botScore
            mov eax, [botScore]
            mov [ebx+1C], eax
            cmp eax, 0A
            jl botNochNichtGewonnen
            mov dword ptr [botScore], 00
            fld [spielfeldMitteX]
            fstp [ballX]
            fld [spielfeldMitteY]
            fstp [ballY]
            botNochNichtGewonnen:
            //
            */
            botScore = 0;
            spielfeldMitteX = 0;
            ballX = 0;
            spielfeldMitteY = 0;
            ballY = 0;
        }

        void newmemBotPunkte() 
        {
            /*
             //original code
             //mov eax,[ebx+1C]
             //
             */
            SetzeUndPruefeBotScore();
            /*
            //original code
            mov [edx+04],eax
            //
            */
            returnBotPunkte();
        }

        void aobBotPunkte()
        {
            newmemBotPunkte();
            /*
             nop
             */
        }

        void returnSpielerpunkte()
        {
            /*
             registersymbol(aobSpielerpunkte)
             */
        }

        void SetzeSpielerpunkteInSpeicher() 
        {
            /*
            // setze spielerScore in Speicher
            mov eax, [spielerScore]
            mov [ebx+18], eax
            cmp eax, 0A
            jl spielerNochNichtGewonnen
            mov dword ptr [spielerScore], 00
            fld [spielfeldMitteX]
            fstp [ballX]
            fld [spielfeldMitteY]
            fstp [ballY]
            spielerNochNichtGewonnen:
            */
            spielerScore = 0;
            ballX = 0;
            ballY = 0;
            spielfeldMitteX = 0;
            spielfeldMitteY = 0;
        }

        void newmemSpielerpunkte()
        {
            /*
            //original code
            //mov eax,[ebx+18]
            //
            */
            SetzeSpielerpunkteInSpeicher();
            /*
            //original code
            mov [edx+04],eax
            //
             */
            returnSpielerpunkte();
        }

        void aobSpielerpunkte() // stelle aobscan vor Aufruf dieser Methode dar
        {
            newmemSpielerpunkte();
            /*
             nop
             */
        }

        void PralleAnDeckeAb()
        {
            /*
            //pralle an der Decke ab
            fld dword ptr [obereWandY]
            fld dword ptr [ballY]
            fcomip st(0),st(1)
            fstp st(0)
            ja istUnterDerDecke
            fld dword ptr [geschwindigkeitY]
            fld dword ptr [negierWert]
            fmul st(0),st(1)
            fstp st(1)
            fstp dword ptr [geschwindigkeitY] // stosse in geschwindigkeitY
            istUnterDerDecke:
            //
             */
        }

        void PralleAmBodenAb()
        {
            /*
            //pralle am Boden ab
            fld dword ptr [ballY]
            fld dword ptr [untereWandY]
            fcomip st(0),st(1)
            fstp st(0)
            ja istUeberDemBoden
            fld dword ptr [geschwindigkeitY]
            fld dword ptr [negierWert]
            fmul st(0),st(1)
            fstp st(1)
            fstp dword ptr [geschwindigkeitY] // stosse in geschwindigkeitY
            istUeberDemBoden:
            //
            */
        }

        void PruefeObBallXAnLinkePlattform()
        {
            /*
             fld [ballX]
            fld [linkePlattformX]
            fcomip st(0),st(1)
            fstp st(0)
            jnae nichtAmSpieler // pruefe ob die X Position der linken Wand nicht groesser ist als von ballX
             */
        }

        void PruefeBallUeberSpieler()
        {
            /*
            //pruefe darueber
            fld [ballY]
            fadd [ballMitte]
            fld [spielerY]
            fcomip st(0),st(1)
            fstp st(0)
            ja nichtAmSpieler
             */
        }

        void PruefeBallUnterSpieler()
        {
            /*
            fld [spielerY]
            fadd [plattformGroesse]
            fld [ballY]
            fcomip st(0),st(1)
            fstp st(0)
            ja nichtAmSpieler //wenn der ball tiefer als bis zur Maximallaenge des Spielers ist dann springe
             */
        }

        void PruefeSpielerBereitsBallBeruehrt()
        {
            /*
            //pruefe Beruehrung
            cmp [spielerHatBeruehrt], 01
            je SpielerHatEbenNochBeruehrt
            mov [spielerHatBeruehrt], 01
             */
        }

        void BerechnePlattformzentrumVonSpielerY()
        {
            /*
             //berechne Plattformzentrum von Y
            fld [spielerY]
            fadd [plattformMitte]
            fstp [plattformZentrumY]
             */
        }

        void BerechneBallzentrumVonY()
        {
            /*
             //berechne Ballzentrum von Y
            fld [ballY]
            fadd [ballMitte]
            fstp [ballZentrumY]
             */
        }

        void BerechneAbsolutBallZentrumVonY()
        {
            /*
             //berechne absolutes Ballzentrum in Abhaengigkeit vom Plattformzentrum
            fld [ballZentrumY]
            fsub [plattformZentrumY]
            fstp [ballZentrumY]
            */
        }

        void DividiereErgebnisVomAbstand()
        {
            /*
             //dividiere das Ergebnis vom Abstand
            fld [divisionsFaktor]
            fld [ballZentrumY]
            fdiv st(0),st(1)
            fstp st(1)
            fstp [geschwindigkeitY]
             */
        }

        void BallNichtAmSpieler()
        {
            /*
            nichtAmSpieler:
            mov [spielerHatBeruehrt], 00
            SpielerHatEbenNochBeruehrt:
            */
        }

        void PralleAmSpielerAb()
        {
            PruefeObBallXAnLinkePlattform();
            PruefeBallUeberSpieler();
            PruefeBallUnterSpieler();
            PruefeSpielerBereitsBallBeruehrt();
            BerechnePlattformzentrumVonSpielerY();
            BerechneBallzentrumVonY();
            BerechneAbsolutBallZentrumVonY();
            DividiereErgebnisVomAbstand();
            NegiereBallgeschwindigkeit();
            BallNichtAmSpieler();
        }

        void PruefeObBallXAnRechtePlattform()
        {
            /*
            fld [ballX]
            fld [rechtePlattformX]
            fcomip st(0),st(1)
            fstp st(0)
            jae nichtAmBot
             */
        }

        void PruefeBallUeberBot()
        {
            /*
            fld [ballY]
            fadd [ballMitte]
            fadd [ballMitte]
            fld [botY]
            fcomip st(0),st(1)
            fstp st(0)
            ja nichtAmBot

             */
        }

        void PruefeBallUnterBot()
        {
            /*
             fld [botY]
            fadd [plattformGroesse]
            fld [ballY]
            fcomip st(0),st(1)
            fstp st(0)
            ja nichtAmBot 
             
             */
        }

        void PruefeBotBereitsBallBeruehrt()
        {
            /*
            cmp [botHatBeruehrt], 01
            je BotHatEbenNochBeruehrt
            mov [botHatBeruehrt], 01
             */
        }
        void BerechnePlattformzentrumVonBotY()
        {
            /*
            fld [botY]
            fadd [plattformMitte]
            fstp [plattformZentrumY]
             */
        }

        void BallNichtAmBot()
        {
            /*
            mov [botHatBeruehrt], 00
            BotHatEbenNochBeruehrt:
             */
        }

        void PralleAmBotAb()
        {
            PruefeObBallXAnRechtePlattform();
            PruefeBallUeberBot();
            PruefeBallUnterBot();
            PruefeBotBereitsBallBeruehrt();
            BerechnePlattformzentrumVonBotY();
            BerechneBallzentrumVonY();
            BerechneAbsolutBallZentrumVonY();
            DividiereErgebnisVomAbstand();
            NegiereBallgeschwindigkeit();
            BallNichtAmBot();
        }

        void ballPhysik() 
        {
            /*
             
             */


            AddiereGeschwindigkeitMitPosition();
            PruefeObEinTorGeschossenWurde();
            PralleAnDeckeAb();
            PralleAmBodenAb();
            PralleAmSpielerAb();
            PralleAmBotAb();

        }


        float ballX,
              ballY,
              spielerY,
              botY,
              plattformGroesse,
              plattformMitte,

              linkePlattformX,
              rechtePlattformX,

              linkeWand,
              rechteWand,

              obereWandY,
              untereWandY,

              geschwindigkeitX,
              geschwindigkeitY,

              negierWert,

              spielfeldMitteX,
              spielfeldMitteY,

              spielerHatBeruehrt,
              botHatBeruehrt,

              botScore,
              spielerScore,

              plattformZentrumY,
              ballZentrumY,

              divisionsFaktor;

        public void ENABLED()
        {
            ReserviereSpeicherFuerVariablen();
        }

        public void DISABLED()
        {
            /*
            db D9 01 D9 41 04
            */
            aobSpielerpunkte();
            /*
            db D9 5F 04 D9 46 10
            */
            aobBotPunkte();
            /*
            db D9 41 10 DF F1
            */
            aobBotY();
            /*
            db 8B 43 1C 89 42 04
            */
            aobPlayerY();
            /*
            db 8B 43 18 89 42 04
            */
            aobBallXY();

            newmemBallXY();
            newmemPlayerY();
            newmemBotY();
            newmemBotPunkte();
            newmemSpielerpunkte();
            ballPhysik();
        }

        void ReserviereSpeicherFuerVariablen()
        {
            newmemBallXY();
            newmemPlayerY();
            newmemBotY();
            newmemBotPunkte();
            newmemSpielerpunkte();
            ballPhysik();

            ballX = 0;
            ballY = 0;
            spielerY = 0;
            botY = 0;
            plattformGroesse = 0;
            plattformMitte = 0;
              
            linkePlattformX = 0;
            rechtePlattformX = 0;
              
            linkeWand = 0;
            rechteWand = 0;
              
            obereWandY = 0;
            untereWandY = 0;
              
            geschwindigkeitX = 0;
            geschwindigkeitY = 0;
              
            negierWert = 0;
              
            spielfeldMitteX = 0;
            spielfeldMitteY = 0;
              
            spielerHatBeruehrt = 0;
            botHatBeruehrt = 0;
              
            botScore = 0;
            spielerScore = 0;
              
            plattformZentrumY = 0;
            ballZentrumY = 0;

            divisionsFaktor = 0;

        }

        void InitialisiereVariablen()
        {
            /*
            aobscan(aobSpielerpunkte, 8B 43 18 89 42 04 E8 ?? ?? ?? ?? 8B D0 C7 45 B8 00 00 48 42 D9 EE)
            */
            aobSpielerpunkte();
            /*
            aobscan(aobBotPoints, 8B 43 1C 89 42 04 E8 ?? ?? ?? ?? 8B D0 8D 7D C8 0F 57 C0 66 0F D6 07)
            */
            aobBotPunkte();
            /*
            aobscan(aobBotY, D9 41 10 DF F1 DD D8 7A 11 76 0F 8D 41 0C D9 05)
            */
            aobBotY();
            /*
            aobscan(aobPlayerY, D9 5F 04 D9 46 10 DB 46 24 D9 5D D4 D9 45 D4 DE C1 DB 05)
            */
            aobPlayerY();
            /*
            aobscan(aobBallXY, D9 01 D9 41 04 8D 4A 14 8B 01 89 45 C4 8B 71 04 8B 79 08 8B 41 0C 89 45 C0 8D 4D E4)
            */
            aobBallXY();

            ballX = 0;
            ballY = 0;
            spielerY = 0;
            botY = 0;
            plattformGroesse = 0;
            plattformMitte = 0;

            linkePlattformX = 0;
            rechtePlattformX = 0;

            linkeWand = 0;
            rechteWand = 0;

            obereWandY = 0;
            untereWandY = 0;

            geschwindigkeitX = 0;
            geschwindigkeitY = 0;

            negierWert = 0;

            spielfeldMitteX = 0;
            spielfeldMitteY = 0;

            spielerHatBeruehrt = 0;
            botHatBeruehrt = 0;

            botScore = 0;
            spielerScore = 0;

            plattformZentrumY = 0;
            ballZentrumY = 0;

            divisionsFaktor = 0;

            SpeicherDefinierung();
        }

        void SpeicherDefinierung()
        {
            newmemBallXY();
            newmemPlayerY();
            newmemBotY();
            newmemBotPunkte();
            newmemSpielerpunkte();
            ballPhysik();
        }

        void AddiereGeschwindigkeitMitPosition()
        {
            /*
            fld dword ptr [ballX]
            fadd dword ptr [geschwindigkeitX]
            fstp dword ptr [ballX]

            fld dword ptr [ballY]
            fadd dword ptr [geschwindigkeitY]
            fstp dword ptr [ballY]
             */
        }

        void PruefeLinkeWand()
        {
            /*
            //pruefe linke Wand
            add [botScore], 01 //fuege vorlaufig einen Punkt hinzu
            fld [ballX]
            fld [linkeWand]
            fcomip st(0),st(1)
            fstp st(0)
            ja TorGeschossen // pruefe ob die X Position der linken Wand nicht groesser ist als von ballX
            sub [botScore], 01 //ziehe den vorlaufigen Punkte ab falls kein Tor
             */
        }

        void PruefeRechteWand()
        {
            /*
             //pruefe rechte Wand
            add [spielerScore], 01
            fld [ballX]
            fld [rechteWand]
            fcomip st(0),st(1)
            fstp st(0)
            jna TorGeschossen // pruefe ob die X Position von ballX nicht groesser ist als von der rechten Wand
            sub [spielerScore], 01
            jmp keinTorGeschossen
            TorGeschossen:
             */
        }

        void SetzeBallZurMitte()
        {
            /*
             
             //setze Ball zum Mittelpunkt
            fld [spielfeldMitteX]
            fstp [ballX]
            fld [spielfeldMitteY]
            fstp [ballY]
             */
        }

        void NegiereBallgeschwindigkeit()
        {
            /*
            //negiere Ballgeschwindigkeit
            fld [geschwindigkeitX]
            fld [negierWert]
            fmul st(0),st(1)
            fstp st(1)
            fstp [geschwindigkeitX]
            keinTorGeschossen:
             */
        }

        void PruefeObEinTorGeschossenWurde()
        {
            PruefeLinkeWand();
            PruefeRechteWand();
            SetzeBallZurMitte();
            NegiereBallgeschwindigkeit();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            PongBall p = new PongBall();
            p.ENABLED();
            p.DISABLED();
        }
    }
}
