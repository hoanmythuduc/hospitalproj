'use client';

export default function WelcomePage() {
  return (
    <div className="flex flex-col items-center justify-center h-full min-h-[60vh] w-full animate-fade-in">
      
      {/* icon/logo*/}
      <div className="w-24 h-24 bg-[#e6f7f1] text-[#00b074] flex items-center justify-center shadow-sm">
        <img src="/logo/HoanMyLogo.png" alt="Logo" className="w-12 h-12 object-contain flex-shrink-0" />
      </div>

      {/* header */}
      <h1 className="text-3xl font-bold text-gray-800 tracking-wide mb-3">
        Welcome
      </h1>

      {/* tẽt */}
      <p className="text-base text-gray-500 text-center max-w-md">
        Select a menu from the sidebar on the left to start working.
      </p>

      <div className="mt-10 flex gap-2">
        <span className="w-2 h-2 rounded-full bg-gray-200"></span>
        <span className="w-2 h-2 rounded-full bg-[#00b074]"></span>
        <span className="w-2 h-2 rounded-full bg-gray-200"></span>
      </div>
      
    </div>
  );
}