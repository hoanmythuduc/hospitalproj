'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { Cuprum } from 'next/font/google';
import { authApi } from '../../api/api'; 
import { Eye, EyeOff } from 'lucide-react';

const cuprum = Cuprum({ subsets: ['latin'], weight: ['400', '700'] });

export default function LoginPage() {
  const router = useRouter();
  const [formData, setFormData] = useState({ username: '', password: '' });
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const [showPassword, setShowPassword] = useState(false); 

  useEffect(() => {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('menu');
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleLogin = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    setError(null);

    const response = await authApi.login(formData);
    if (response.error) {
      setError(response.error);
      setIsLoading(false);
      return;
    }
    const { token, userCode, permissions, id } = response.data.data;
    localStorage.setItem('token', token);
    localStorage.setItem('userCode', userCode);
    localStorage.setItem('userId', id);
    localStorage.setItem('menu', JSON.stringify(permissions)); 
    console.log(permissions)
    console.log(token)
    router.push('/welcome-page'); 
  };

  return (
    <div className={`flex min-h-screen w-full bg-[#E6EFFF] ${cuprum.className}`}>
      
      <div className="flex w-full flex-col justify-center px-10 md:w-[40%] lg:px-20 xl:px-32">
        <div className="mx-auto w-full max-w-[450px]">
          
          <h1 className="mb-10 text-[3.5rem] font-bold text-black lg:text-[4rem]">
            Login
          </h1>

          {error && (
            <div className="mb-6 rounded bg-red-100 p-3 text-center text-sm text-red-600 shadow">
              {error}
            </div>
          )}

          <form onSubmit={handleLogin} className="flex flex-col gap-6">
            
            <div className="flex flex-col gap-2">
              <label className="text-[1.2rem] font-bold text-black">
                Username
              </label>
              <div className="relative flex items-center">
                <div className="absolute left-4 text-gray-500">
                  <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                    <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path>
                    <circle cx="12" cy="7" r="4"></circle>
                  </svg>
                </div>
                <input
                  type="text"
                  name="username"         
                  value={formData.username} 
                  onChange={handleChange}   
                  className="h-[60px] w-full rounded-[5px] bg-white pl-12 pr-4 text-xl text-black shadow-md outline-none focus:ring-2 focus:ring-blue-400"
                  required
                />
              </div>
            </div>

            <div className="flex flex-col gap-2">
              <label className="text-[1.2rem] font-bold text-black">
                Password
              </label>
              <div className="relative flex items-center">
                <div className="absolute left-4 text-gray-500">
                  <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                    <rect x="3" y="11" width="18" height="11" rx="2" ry="2"></rect>
                    <path d="M7 11V7a5 5 0 0 1 10 0v4"></path>
                  </svg>
                </div>
                <input
                  type={showPassword ? "text" : "password"} 
                  name="password"         
                  value={formData.password} 
                  onChange={handleChange}   
                  className="h-[60px] w-full rounded-[5px] bg-white pl-12 pr-12 text-xl text-black shadow-md outline-none focus:ring-2 focus:ring-blue-400"
                  required
                />
                <button
                  type="button"
                  onClick={() => setShowPassword(!showPassword)}
                  className="absolute right-4 text-gray-400 hover:text-gray-600 focus:outline-none"
                >
                  {showPassword ? <EyeOff size={24} /> : <Eye size={24} />}
                </button>
              </div>
            </div>

            <div className="flex justify-end mt-[-10px]">
              <a href="#" className="text-lg text-[#3b82f6] underline hover:text-blue-700">
                Forgot password
              </a>
            </div>

            <button
              type="submit"
              disabled={isLoading}
              className="mt-2 h-[60px] w-full rounded-[5px] bg-[#4780E3] text-2xl font-normal text-white shadow-md transition-colors hover:bg-[#3466bd] disabled:opacity-50"
            >
              {isLoading ? 'Logging in...' : 'Login'}
            </button>
          </form>

          <div className="mt-6 flex justify-center text-lg text-[#555]">
            Don't have an account?{' '}
            <a href="#" className="ml-1 font-bold text-[#2A5C9A] underline hover:text-[#1d4272]">
              Register
            </a>
          </div>

        </div>
      </div>

      <div 
        className="hidden md:block md:w-[70%] bg-cover bg-center bg-no-repeat"
        style={{ backgroundImage: "url('/image 2.png')" }} 
      /> 
    </div>
  );
}