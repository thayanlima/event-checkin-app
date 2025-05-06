import { useEffect, useState } from 'react';
import axios from 'axios';

export default function EventSelector({ onSelect }) {
  const [events, setEvents] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchEvents = async () => {
      try {
        const response = await axios.get('http://localhost:5201/api/events');
        setEvents(response.data);
        setLoading(false);
      } catch (error) {
        console.error('Erro ao buscar eventos:', error);
        setLoading(false);
      }
    };

    fetchEvents();
  }, []);

  return (
    <div className="bg-white rounded-lg shadow p-6">
      <h2 className="text-xl font-semibold text-gray-800 mb-4 flex items-center gap-2">
        🎯 Escolha o Evento
      </h2>

      {loading ? (
        <p className="text-gray-500">Carregando eventos...</p>
      ) : events.length === 0 ? (
        <p className="text-red-500">Nenhum evento disponível.</p>
      ) : (
        <select
          id="event-select"
          onChange={(e) => onSelect(e.target.value)}
          className="block w-full px-4 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500 transition"
          defaultValue=""
        >
          <option value="" disabled>
            — Selecione um evento —
          </option>
          {events.map((ev) => (
            <option key={ev.id} value={ev.id}>
              {ev.name}
            </option>
          ))}
        </select>
      )}
    </div>
  );
}
