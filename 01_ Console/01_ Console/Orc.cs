﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _01__Console
{
    internal class Orc : Human
    {
        int rage = 0; // 오크만의 고유변수는 분노..
        const int MaxRage = 100; // const-> 상수로 결정. 시작부터 끝까지 값이 변하지 않는다.
        bool berserker = false;

        public Orc(string _newName) : base(_newName)
        {
            
           
        } // 생성자같은 경우 상속이 안되니 무조건 새로만들어야됨

        public override void GenerateStatus()
        {
          
            base.GenerateStatus();
            strenth += rand.Next(10) + 1;// 오크라 힘을 추가로 더함
            rage = 0; // 시작 분노는 0
        }
        void BerserkenMode(bool on)
        {
            berserker = on;
            if (berserker)
            {
                strenth *= 2;


            }
            else
            {
                strenth = strenth >> 1; 
                //인티저 일때만 가능 (2의1승으로)절반으로 줄이기 -> a >> b => 2^b로 나눈다

            }

        }

        


        public override void TakeDamage(int damage)
        {   // 맞을 때마다 최대 분노의 1/10 증가 + 데미지 10당 1씩 증가
            rage += (int)(MaxRage * 0.1f + damage*0.1f); // 분노가 최대 분노를 넘어서면
            if (rage >= MaxRage) 
            {
                BerserkenMode(true);   //버서커 모드가된다
            }
            base.TakeDamage(damage); // 플레이어한테 데미지 전달
        }

        public override void PrintStatus()
        {
            Console.WriteLine("┌─────────────────┐");
            Console.WriteLine($"이름\t: {name}");
            Console.WriteLine($"HP\t: {hp} / {maxHP}");
            Console.WriteLine($"Rage\t: {rage,4}");
            Console.WriteLine($"힘\t: {strenth,2}");
            Console.WriteLine($"방어\t: {defence,2}");
            Console.WriteLine($"민첩\t: {dexteriy,2}");
            Console.WriteLine($"지능\t: {intellegence,2}");
            Console.WriteLine("└─────────────────┘");
        } // 브레이킹 포인트 찾는것은 그변수 클릭해서 모든참조 찾기 -> 잘못 출력된 곳을 발견하면 그곳 위주로 어떻게 처리되는지 확인필요!
    }
 }