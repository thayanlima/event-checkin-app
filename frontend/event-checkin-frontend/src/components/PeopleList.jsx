import { useEffect, useState } from "react";
import axios from "axios";

export default function PeopleList({ eventId }) {
  const [people, setPeople] = useState([]);

  useEffect(() => {
    const fetchPeople = async () => {
      try {
        const response = await axios.get(`http://localhost:5201/api/people/${eventId}`);
        setPeople(response.data);
      } catch (error) {
        console.error("Erro ao buscar pessoas:", error);
      }
    };

    fetchPeople();
    const interval = setInterval(fetchPeople, 5000);
    return () => clearInterval(interval);
  }, [eventId]);

  const handleCheckIn = async (id) => {
    try {
      await axios.post(`http://localhost:5201/api/people/${id}/checkin`);
    } catch (err) {
      console.error("Erro no check-in:", err);
    }
  };

  const handleCheckOut = async (id) => {
    try {
      await axios.post(`http://localhost:5201/api/people/${id}/checkout`);
    } catch (err) {
      console.error("Erro no check-out:", err);
    }
  };

  const formatDate = (date) => {
    if (!date) return "—";
    const d = new Date(date);
    return `${d.toLocaleDateString()} ${d.toLocaleTimeString()}`;
  };

  return (
    <div className="bg-white p-6 rounded-lg shadow">
      <h2 className="text-2xl font-semibold text-gray-800 mb-6">👥 Pessoas Registradas</h2>
      <div className="overflow-x-auto">
        <table className="min-w-full table-auto">
          <thead className="bg-blue-200 text-gray-700">
            <tr>
              <th className="px-6 py-3 text-left">Nome</th>
              <th className="px-6 py-3 text-left">Cargo</th>
              <th className="px-6 py-3 text-left">Empresa</th>
              <th className="px-6 py-3 text-left">Check-In</th>
              <th className="px-6 py-3 text-left">Check-Out</th>
              <th className="px-6 py-3 text-left">Ações</th>
            </tr>
          </thead>
          <tbody className="bg-white">
            {people.map((person) => (
              <tr key={person.id} className="border-t border-gray-200">
                <td className="px-6 py-4">{person.firstName} {person.lastName}</td>
                <td className="px-6 py-4">{person.title}</td>
                <td className="px-6 py-4">{person.company}</td>
                <td className="px-6 py-4">{formatDate(person.checkInAt)}</td>
                <td className="px-6 py-4">{formatDate(person.checkOutAt)}</td>
                <td className="px-6 py-4">
                  {!person.checkInAt ? (
                    <button
                      onClick={() => handleCheckIn(person.id)}
                      className="bg-green-500 hover:bg-green-600 text-white px-4 py-2 rounded"
                    >
                      ✅ Check-In
                    </button>
                  ) : !person.checkOutAt ? (
                    <button
                      onClick={() => handleCheckOut(person.id)}
                      className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded"
                    >
                      ⏹ Check-Out
                    </button>
                  ) : (
                    <span className="text-sm text-gray-500">Finalizado</span>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
