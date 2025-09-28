using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitasMedicas
{
    internal class Cita
    {
        public int IdCita { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
    }

    internal class Program
    {
        static List<Cita> citas = new List<Cita>();
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE CITAS MÉDICAS ===");
                Console.WriteLine("1. Crear Cita");
                Console.WriteLine("2. Leer (Listar) Citas");
                Console.WriteLine("3. Actualizar Cita");
                Console.WriteLine("4. Eliminar Cita");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: CrearCita(); break;
                    case 2: LeerCitas(); break;
                    case 3: ActualizarCita(); break;
                    case 4: EliminarCita(); break;
                    case 5: Console.WriteLine("Saliendo..."); break;
                    default: Console.WriteLine("Opción inválida"); break;

                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 5);
        }

        //BLOQUE DE INSERTAR
        static void CrearCita()
        { 
            Cita nuevaCita = new Cita();

            Console.WriteLine("Ingrese ID de la cita: ");
            nuevaCita.IdCita = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nombre del paciente: ");
            nuevaCita.Paciente = Console.ReadLine();

            Console.WriteLine("Ingrese nombre del medico: ");
            nuevaCita.Medico = Console.ReadLine();

            Console.WriteLine("Ingrese fecha (YYYY-MM-DD): ");
            nuevaCita.Fecha = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese hora (HH:MM): ");
            nuevaCita.Hora = Console.ReadLine();

            citas.Add(nuevaCita);
            Console.WriteLine("Cita creada exitosamente.");
        }
        //READ
        static void LeerCitas()
        {
            Console.WriteLine("\n=== LISTADO DE CITAS ===");
            if (citas.Count == 0)
            {
                Console.WriteLine("No hay citas registradas.");
            }
            else
            {
                foreach (var cita in citas)
                {
                    Console.WriteLine($"ID: {cita.IdCita}, Paciente: {cita.Paciente}, Médico: {cita.Medico}, Fecha: {cita.Fecha.ToShortDateString()}, Hora: {cita.Hora}");
                }
            }

        }
        //UPDATE
        static void ActualizarCita()
        {
            Console.Write("Ingrese el ID de la cita a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            Cita cita = citas.Find(c => c.IdCita == id);

            if (cita != null)
            {
                Console.Write("Nuevo nombre del paciente: ");
                cita.Paciente = Console.ReadLine();

                Console.Write("Nuevo nombre del médico: ");
                cita.Medico = Console.ReadLine();

                Console.Write("Nueva fecha (YYYY-MM-DD): ");
                cita.Fecha = DateTime.Parse(Console.ReadLine());

                Console.Write("Nueva hora (HH:MM): ");
                cita.Hora = Console.ReadLine();

                Console.WriteLine("Cita actualizada correctamente.");
            }
            else
            {
                Console.WriteLine("Cita no encontrada.");
            }
        }
        //DELETE
        static void EliminarCita()
        {
            Console.Write("Ingrese el ID de la cita a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            Cita cita = citas.Find(c => c.IdCita == id);

            if (cita != null)
            {
                citas.Remove(cita);
                Console.WriteLine("Cita eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Cita no encontrada.");
            }
        }
    }
}

