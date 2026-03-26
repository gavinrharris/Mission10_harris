import React from 'react';
import HeadingComponent from './components/HeadingComponent';
import BowlerTable from './components/BowlerTable';

// Main app component - combines the heading and table components
function App() {
  return (
    <div>
      <HeadingComponent />
      <BowlerTable />
    </div>
  );
}

export default App;
