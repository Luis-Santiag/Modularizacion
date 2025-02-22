using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Calculadora básica");
            Console.WriteLine("2. Validación de contraseña");
            Console.WriteLine("3. Números primos");
            Console.WriteLine("4. Suma de números pares");
            Console.WriteLine("5. Conversión de temperatura");
            Console.WriteLine("6. Contador de vocales");
            Console.WriteLine("7. Cálculo de factorial");
            Console.WriteLine("8. Juego de adivinanza");
            Console.WriteLine("9. Paso por referencia");
            Console.WriteLine("10. Tabla de multiplicar");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CalculadoraBasica();
                    break;
                case 2:
                    ValidacionContrasena();
                    break;
                case 3:
                    NumerosPrimos();
                    break;
                case 4:
                    NumerosPares();
                    break;
                case 5:
                    Temperatura();
                    break;
                case 6:
                    Vocales();
                    break;
                case 7:
                    CalculoFactorial();
                    break;
                case 8:
                    Adivinanza();
                    break;
                case 9:
                    Referencia();
                    break;
                case 10:
                    TablaMultiplicar();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }

    static void CalculadoraBasica()
    {
        Console.WriteLine("Calculadora Básica");
        double num1, num2;
        Console.Write("Ingrese el primer número: ");
        if (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Número no válido.");
            return;
        }
        Console.Write("Ingrese el segundo número: ");
        if (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Número no válido.");
            return;
        }
        Console.Write("Seleccione la operación (+, -, *, /): ");
        char operacion = Console.ReadLine()[0];

        switch (operacion)
        {
            case '+':
                Console.WriteLine($"Resultado: {num1 + num2}");
                break;
            case '-':
                Console.WriteLine($"Resultado: {num1 - num2}");
                break;
            case '*':
                Console.WriteLine($"Resultado: {num1 * num2}");
                break;
            case '/':
                if (num2 != 0)
                    Console.WriteLine($"Resultado: {num1 / num2}");
                else
                    Console.WriteLine("División por cero no permitida.");
                break;
            default:
                Console.WriteLine("Operación no válida.");
                break;
        }
    }

    static void ValidacionContrasena()
    {
        string contrasena;
        do
        {
            Console.Write("Ingrese la contraseña: ");
            contrasena = Console.ReadLine();
            if (contrasena != "1234")
                Console.WriteLine("Contraseña incorrecta. Intente de nuevo.");
        } while (contrasena != "1234");
        Console.WriteLine("Acceso concedido.");
    }

    static void NumerosPrimos()
    {
        Console.Write("Ingrese un número: ");
        int num = int.Parse(Console.ReadLine());
        if (EsPrimo(num))
            Console.WriteLine($"{num} es un número primo.");
        else
            Console.WriteLine($"{num} no es un número primo.");
    }

    static bool EsPrimo(int num)
    {
        if (num <= 1)
            return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    static void NumerosPares()
    {
        int suma = 0;
        int num;
        Console.WriteLine("Ingrese números enteros (0 para terminar):");
        while (true)
        {
            num = int.Parse(Console.ReadLine());
            if (num == 0)
                break;
            if (num % 2 == 0)
                suma += num;
        }
        Console.WriteLine($"La suma de los números pares es: {suma}");
    }

    static void Temperatura()
    {
        Console.Write("Seleccione la conversión (1: Celsius a Fahrenheit, 2: Fahrenheit a Celsius): ");
        int opcion = int.Parse(Console.ReadLine());
        double temp;
        Console.Write("Ingrese la temperatura: ");
        if (!double.TryParse(Console.ReadLine(), out temp))
        {
            Console.WriteLine("Temperatura no válida.");
            return;
        }
        if (opcion == 1)
            Console.WriteLine($"{temp}°C es equivalente a {CelsiusAFahrenheit(temp)}°F");
        else if (opcion == 2)
            Console.WriteLine($"{temp}°F es equivalente a {FahrenheitACelsius(temp)}°C");
        else
            Console.WriteLine("Opción no válida.");
    }

    static double CelsiusAFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    static double FahrenheitACelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static void Vocales()
    {
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine();
        int contador = ContarVocales(frase);
        Console.WriteLine($"La frase contiene {contador} vocales.");
    }

    static int ContarVocales(string frase)
    {
        int contador = 0;
        foreach (char c in frase.ToLower())
        {
            if ("aeiou".Contains(c))
                contador++;
        }
        return contador;
    }

    static void CalculoFactorial()
    {
        Console.Write("Ingrese un número: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine($"El factorial de {num} es {Factorial(num)}");
    }

    static int Factorial(int num)
    {
        int resultado = 1;
        for (int i = 2; i <= num; i++)
            resultado *= i;
        return resultado;
    }

    static void Adivinanza()
    {
        Random rand = new Random();
        int numeroSecreto = rand.Next(1, 101);
        int intento;
        do
        {
            Console.Write("Adivine el número (1-100): ");
            intento = int.Parse(Console.ReadLine());
            if (intento < numeroSecreto)
                Console.WriteLine("Demasiado bajo.");
            else if (intento > numeroSecreto)
                Console.WriteLine("Demasiado alto.");
        } while (intento != numeroSecreto);
        Console.WriteLine("¡Adivinaste!");
    }

    static void Referencia()
    {
        Console.Write("Ingrese el primer número: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el segundo número: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine($"Valores originales: num1 = {num1}, num2 = {num2}");
        Intercambiar(ref num1, ref num2);
        Console.WriteLine($"Valores intercambiados: num1 = {num1}, num2 = {num2}");
    }

    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void TablaMultiplicar()
    {
        Console.Write("Ingrese un número: ");
        int num = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 10; i++)
            Console.WriteLine($"{num} x {i} = {num * i}");
    }
}