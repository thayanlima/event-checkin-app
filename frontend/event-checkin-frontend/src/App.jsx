import { useState } from "react";
import EventSelector from "./components/EventSelector";
import PeopleList from "./components/PeopleList";
import EventSummary from "./components/EventSummary";

function App() {
  const [selectedEvent, setSelectedEvent] = useState(null);

  return (
    <div className="min-h-screen bg-gradient-to-b from-blue-50 to-white p-8">
      <h1 className="text-3xl font-bold text-blue-600 text-center mb-8">
        Event Check-In App
      </h1>
      
      <div className="max-w-4xl mx-auto">
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
