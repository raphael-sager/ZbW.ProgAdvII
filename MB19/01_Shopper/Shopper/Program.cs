using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace Shopper {
    class Program {
        static void Main(string[] args) {
            //var masterCard = new MasterCard(new EftTerminal());
            //var shopperOne = new Shopper(masterCard);

            // own resolver
            Resolver resolver = new Resolver();
            resolver.Register<CreditCard, MasterCard>();
            resolver.Register<ITerminal, EftTerminal>();
            var shopper = resolver.Resolve<Shopper>();


            // autofac
            //var containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<Visa>().As<CreditCard>();
            //containerBuilder.RegisterType<EftTerminal>().AsImplementedInterfaces();

            //var container = containerBuilder.Build();

            //var shopper = container.Resolve<Shopper>();



            shopper.Charge();


            //var visa = new Visa(new EftTerminal());
            //var shopperTwo = new Shopper(visa);
            //shopperTwo.Charge();

            Console.ReadKey();
        }
    }

    public class Resolver
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();
        public void Register<TFrom, TTo>()
        {
            this._dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }

        public T Resolve<T>()
        {
            var resolvingType = typeof(T);
            return (T)Resolve(resolvingType);
        }

        public object Resolve(Type resolvingType)
        {
            if (_dependencyMap.ContainsKey(resolvingType))
            {
                resolvingType = _dependencyMap[resolvingType];
            }

            var ctor = resolvingType.GetConstructors().First();
            var parameters = ctor.GetParameters();

            if (parameters.Length == 0)
            {
                return Activator.CreateInstance(resolvingType);
            }

            var parameterList = new List<object>();
            foreach (var para in parameters)
            {
                var paraType = para.ParameterType;
                var paraValue = this.Resolve(paraType);
                parameterList.Add(paraValue);
            }
            return ctor.Invoke(parameterList.ToArray());
        }
    }

    public class Shopper
    {
        private readonly CreditCard _creditCard;

        public Shopper(CreditCard creditCard)
        {
            _creditCard = creditCard;
        }

        public Shopper(MasterCard creditCard) {
            this._creditCard = creditCard;
        }

        public void Charge() {
            var chargeMessage = _creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }

    public abstract class CreditCard {
        private readonly ITerminal _terminal;

        protected CreditCard(ITerminal terminal) {
            this._terminal = terminal;
        }
        public void TrxTerminal() {
            this._terminal.Trx();
        }
        public abstract string Charge();
    }

    public class Visa : CreditCard {
        public Visa(ITerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Chaaaarging with the Visa!";
        }
    }

    public class MasterCard  : CreditCard {
        public MasterCard(ITerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Swiping the MasterCard!";
        }
    }

    public class EftTerminal : ITerminal {
        public void Trx() {
            Console.WriteLine("Do Eft-Transaction.");
        }
    }

    public interface ITerminal
    {
        void Trx();
    }
}
