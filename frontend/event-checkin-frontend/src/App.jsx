import React, { useState } from "react";
import EventSelector from "./components/EventSelector";
import PeopleList from "./components/PeopleList";
import EventSummary from "./components/EventSummary";

function App() {
  const [selectedEvent, setSelectedEvent] = useState(null);

  return (
    <div className="min-h-screen bg-gradient-to-b from-blue-100 via-white to-white p-6">
      <h1 className="text-4xl font-bold text-blue-800 text-center mb-10 drop-shadow">
        Sistema de Check-In de Eventos
      </h1>

      <div className="max-w-7xl mx-auto space-y-10">
        <EventSelector onSelect={setSelectedEvent} />
        {selectedEvent && (
          <>
            <PeopleList eventId={selectedEvent} />
            <EventSummary eventId={selectedEvent} />
          </>
        )}
      </div>
    </div>
  );
}

export default App;
