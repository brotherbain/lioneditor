# Copyright 2020, John Gaskin <brotherbain@gmail.com>
#
# This file is part of LionEditor.
#
# LionEditor is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# LionEditor is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with LionEditor.  If not, see <http://www.gnu.org/licenses/>.
require 'spec_helper'
require_relative '../../data_types/proposition'
include Datatypes

RSpec.describe Proposition do
  %i[day_increment proposition_number days_counter days_needed number_chars].each do |prop|
    it "has a #{prop}" do
      proposition = Proposition.new({prop => 1})
      expect(proposition.public_send(prop)).to be(1)
    end
  end

  it "has a starting location" do
    location = Object.new
    proposition = Proposition.new(starting_location: location)
    expect(proposition.starting_location).to be(location)
  end

  it "has characters" do
    characters = [Object.new]
    proposition = Proposition.new(characters: characters)
    expect(proposition.characters).to be(characters)
  end
end
