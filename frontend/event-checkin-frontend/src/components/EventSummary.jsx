import { useEffect, useState } from "react";
import axios from "axios";

export default function EventSummary({ eventId }) {
  const [summary, setSummary] = useState(null);

  useEffect(() => {
    const fetchSummary = async () => {
      try {
        const response = await axios.get(`http://localhost:5201/api/events/${eventId}/summary`);
        setSummary(response.data);
      } catch (error) {
        console.error("Erro ao buscar resumo:", error);
      }
    };

    fetchSummary();
    const interval = setInterval(fetchSummary, 5000);
    return () => clearInterval(interval);
  }, [eventId]);

  if (!summary) return null;

  return (
    <div className="bg-white p-6 rounded-lg shadow">
      <h2 className="text-2xl font-semibold text-gray-800 mb-4">📊 Resumo do Evento</h2>

      <div className="grid grid-cols-1 sm:grid-cols-3 gap-6 mb-6">
        <div className="bg-blue-100 p-4 rounded-lg text-center">
          <h3 className="text-blue-800 font-semibold">Presentes</h3>
          <p className="text-2xl font-bold">{summary.attendeeCount}</p>
        </div>
        <div className="bg-yellow-100 p-4 rounded-lg text-center">
          <h3 className="text-yellow-800 font-semibold">Não Checkados</h3>
          <p className="text-2xl font-bold">{summary.notCheckedInCount}</p>
        </div>
        <div className="bg-gray-100 p-4 rounded-lg text-center">
          <h3 className="text-gray-800 font-semibold">Total</h3>
          <p className="text-2xl font-bold">{summary.attendeeCount + summary.notCheckedInCount}</p>
        </div>
      </div>

      <div>
        <h3 className="font-medium text-gray-700 mb-2">🔍 Por Empresa</h3>
        <ul className="space-y-2">
          {summary.companyBreakdown.map((company) => (
            <li key={company.name} className="flex justify-between text-sm text-gray-600">
              <span>{company.name}</span>
              <span>{company.count}</span>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
