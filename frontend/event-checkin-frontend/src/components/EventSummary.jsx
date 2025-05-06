import { useEffect, useState } from 'react';
import axios from 'axios';

export default function EventSummary({ eventId }) {
  const [summary, setSummary] = useState(null);

  useEffect(() => {
    const fetchSummary = async () => {
      try {
        const response = await axios.get(`http://localhost:5201/api/events/${eventId}/summary`);
        setSummary(response.data);
      } catch (error) {
        console.error('Erro ao buscar o resumo do evento:', error);
      }
    };

    fetchSummary();
    const interval = setInterval(fetchSummary, 5000); // Atualiza a cada 5 segundos

    return () => clearInterval(interval);
  }, [eventId]);

  if (!summary) return null;

  return (
    <div className="mt-8 bg-white rounded-lg shadow p-6">
      <h2 className="text-xl font-semibold mb-4">Resumo do Evento</h2>
      
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        <div className="bg-blue-50 p-4 rounded-lg">
          <h3 className="font-medium text-blue-800">Participantes Atuais</h3>
          <p className="text-2xl font-bold">{summary.attendeeCount}</p>
        </div>
        
        <div className="bg-green-50 p-4 rounded-lg">
          <h3 className="font-medium text-green-800">Não Verificados</h3>
          <p className="text-2xl font-bold">{summary.notCheckedInCount}</p>
        </div>
      </div>
      
      <div className="mt-6">
        <h3 className="font-medium mb-2">Distribuição por Empresa</h3>
        <ul className="space-y-2">
          {summary.companyBreakdown.map((company) => (
            <li key={company.company} className="flex justify-between">
              <span>{company.company}</span>
              <span>{company.count}</span>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
